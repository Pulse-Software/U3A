using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class ClassSchedule
    {
        public ClassSchedule() { }
        public int AppointmentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? Label { get; set; }
        public int Status { get; set; }
        public bool AllDay { get; set; }
        public string Recurrence { get; set; }
        public Class Class { get; set; }
    }

    public class LabelObject
    {
        public int Id { get; set; }
        public string LabelCaption { get; set; }
        public string BackgroundCssClass { get; set; }
        public string TextCssClass { get; set; }
    }

    public class Resource
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public bool IsGroup { get; set; }
        public string TextCss { get; set; }
        public string BackgroundCss { get; set; }
        public string ImageFileName => $"Employees/{Id + 1}.jpg";
        public override bool Equals(object obj) {
            Resource resource = obj as Resource;
            return resource != null && resource.Id == Id;
        }
        public override int GetHashCode() {
            return Id;
        }
    }
}
