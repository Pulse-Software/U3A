﻿using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using U3A.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using DevExpress.CodeParser;

namespace U3A.UI.Reports
{
    public class CustomReportStorageWebExtension : ReportStorageWebExtension {
        public string TempDirectory {get; private set;}
        readonly string ReportDirectory;
        const string FileExtension = ".repx";

        public CustomReportStorageWebExtension(IWebHostEnvironment env, IDbContextFactory<U3ADbContext> U3Adbfactory) {
            string? identity;
            using (var dbc = U3Adbfactory.CreateDbContext()) {
                identity = dbc.TenantInfo.Identifier;
            }
            var homeDirectory = Path.Combine(env.ContentRootPath, "Reports");
            if (!Directory.Exists(homeDirectory)) {
                Directory.CreateDirectory(homeDirectory);
            }
            ReportDirectory = Path.Combine(homeDirectory, identity);
            if (!Directory.Exists(ReportDirectory)) {
                Directory.CreateDirectory(ReportDirectory);
            }
            TempDirectory = Path.Combine(env.WebRootPath, "Temp");
            if (!Directory.Exists(TempDirectory)) {
                Directory.CreateDirectory(TempDirectory);
            }
            var defaultDirectory = Path.Combine(homeDirectory, "Default");
            DeleteOldTempFiles(TempDirectory);
            CopyDefaultFiles(defaultDirectory,ReportDirectory);
        }

        private void DeleteOldTempFiles(string dirName) {
            Directory.GetFiles(dirName)
                 .Select(f => new FileInfo(f))
                 .Where(f => f.LastAccessTime < DateTime.Now.AddHours(-6))
                 .ToList()
                 .ForEach(f => f.Delete());
        }
        private void CopyDefaultFiles(string SourceFolder,string DestFolder) {
            // Copy the files if they do not exist.
            foreach (string s in System.IO.Directory.GetFiles(SourceFolder)) {
                // Use static Path methods to extract only the file name from the path.
               var fileName = System.IO.Path.GetFileName(s);
               var destFile = System.IO.Path.Combine(DestFolder, fileName);
             if (!File.Exists(destFile))  File.Copy(s, destFile, true);
            }
        }

        private bool IsWithinReportsFolder(string url, string folder) {
            var rootDirectory = new DirectoryInfo(folder);
            var fileInfo = new FileInfo(Path.Combine(folder, url));
            return fileInfo.Directory.FullName.ToLower().StartsWith(rootDirectory.FullName.ToLower());
        }

        public override bool CanSetData(string url) {
            // Determines whether it is possible to store a report by a given URL. 
            // For instance, make the CanSetData method return false for reports
            // that should be read-only in your storage. 
            // This method is called only for valid URLs
            // (if the IsValidUrl method returns true) before calling the SetData method.

            return true;
        }

        public override bool IsValidUrl(string url) {
            // Determines whether the URL passed to the current Report Storage is valid. 
            // For instance, implement your own logic to prohibit URLs that contain white spaces
            // or other special characters. 
            // This method is called before the CanSetData and GetData methods.

            return Path.GetFileName(url) == url;
        }

        public override byte[] GetData(string url) {
            // Returns report layout data stored in a Report Storage using the specified URL. 
            // This method is called only for valid URLs after the IsValidUrl method is called.
            try {
                if (Directory.EnumerateFiles(ReportDirectory)
                    .Select(Path.GetFileNameWithoutExtension).Contains(url)) {
                    return File.ReadAllBytes(Path.Combine(ReportDirectory, url + FileExtension));
                }
            }
            catch (Exception ex) {
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException(
                    "Could not get report data.", ex);
            }
            throw new DevExpress.XtraReports.Web.ClientControls.FaultException(
                string.Format("Could not find report '{0}'.", url));
        }

        public override Dictionary<string, string> GetUrls() {
            // Returns a dictionary of the existing report URLs and display names. 
            // This method is called when running the Report Designer, 
            // before the Open Report and Save Report dialogs are shown
            // and after a new report is saved to storage.

            return Directory.GetFiles(ReportDirectory, "*" + FileExtension)
                                    .Select(Path.GetFileNameWithoutExtension)
                                    .ToDictionary<string, string>(x => x);
        }

        public override void SetData(XtraReport report, string url) {
            // Stores the specified report to a Report Storage using the specified URL. 
            // This method is called only after the IsValidUrl and CanSetData methods are called.
            if (!IsWithinReportsFolder(url, ReportDirectory))
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException(
                    "Invalid report name.");
            report.SaveLayoutToXml(Path.Combine(ReportDirectory, url + FileExtension));
        }

        public override string SetNewData(XtraReport report, string defaultUrl) {
            // Stores the specified report using a new URL. 
            // The IsValidUrl and CanSetData methods are never called before this method. 
            // You can validate and correct the specified URL directly
            // in the SetNewData method implementation 
            // and return the resulting URL used to save a report in your storage.
            SetData(report, defaultUrl);
            return defaultUrl;
        }
    }
}