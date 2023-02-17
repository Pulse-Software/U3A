using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using U3A.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace U3A.Database
{
    public abstract class U3ADbContextBase : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        //Set in U3ADbContext ctor
        internal AuthenticationStateProvider authenticationStateProvider;

        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<PublicHoliday> PublicHoliday { get; set; }
        public DbSet<Occurrence> Occurrence { get; set; }
        public DbSet<CourseParticipationType> CourseParticpationType { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<WeekDay> WeekDay { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<CancelClass> CancelClass { get; set; }
        public DbSet<AttendClass> AttendClass { get; set; }
        public DbSet<AttendClassStatus> AttendClassStatus { get; set; }
        public DbSet<CourseType> CourseType { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonImport> PersonImport { get; set; }
        public DbSet<PersonImportError> PersonImportError { get; set; }
        public DbSet<Enrolment> Enrolment { get; set; }
        public DbSet<AttendanceHistory> AttendanceHistory { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplate { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<EmailHistory> EmailHistory { get; set; }
        public DbSet<Committee> Committee { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<ReceiptDataImport> ReceiptDataImport { get; set; }
        public DbSet<SendMail> SendMail { get; set; }
        public DbSet<OnlinePaymentStatus> OnlinePaymentStatus { get; set; }
        public DbSet<Dropout> Dropout { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess) {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                    CancellationToken cancellationToken = default(CancellationToken)) {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity) {
            if (entity is Enrolment) {
                CreateDropout(entity);
            }
            return base.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<object> entities) {
            if (entities is IEnumerable<Enrolment>) {
                foreach (var entity in entities) {
                    CreateDropout(entity);
                }
            }
            base.RemoveRange(entities);
        }
        private void CreateDropout<TEntity>(TEntity entity) where TEntity : class {
            var e = Enrolment.Find(( entity as Enrolment).ID);
            if (e != null) {
                var d = new Dropout() {
                    CourseID = e.CourseID,
                    Created = e.Created,
                    DateEnrolled = e.DateEnrolled,
                    IsWaitlisted = e.IsWaitlisted,
                    PersonID = e.PersonID,
                    TermID = e.TermID
                };
                if (e.ClassID != null) { d.Class = Class.Find(e.ClassID); }
                if (authenticationStateProvider != null) {
                    d.DeletedBy = authenticationStateProvider.GetAuthenticationStateAsync().Result.User.Identity.Name;
                }
                base.Add(d);
            }
        }


        private void OnBeforeSaving() {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.Now;
            var rnd = new Random(utcNow.Millisecond);
            foreach (var entry in entries) {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable) {
                    switch (entry.State) {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedOn = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedOn").IsModified = false;
                            if (entry.Entity is Person) entry.Property("PersonID").IsModified = false;
                            if (authenticationStateProvider != null) {
                                trackable.User = authenticationStateProvider.GetAuthenticationStateAsync().Result.User.Identity.Name;
                            }
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedOn = utcNow;
                            trackable.UpdatedOn = utcNow;
                            if (authenticationStateProvider != null) {
                                trackable.User = authenticationStateProvider.GetAuthenticationStateAsync().Result.User.Identity.Name;
                            }
                            break;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DocumentType>()
                        .Property(x => x.ID).ValueGeneratedNever();
            modelBuilder.Entity<DocumentType>().HasData(
                        new DocumentType() {
                            ID = 0,
                            Name = "Email",
                            IsEmail = true,
                            IsPostal = false,
                            IsSMS = false,
                            IsEnrolmentSubDocument = false,
                            IsREceiptSubDocument = false
                        },
                        new DocumentType() {
                            ID = 1,
                            Name = "Postal",
                            IsEmail = false,
                            IsPostal = true,
                            IsSMS = false,
                            IsEnrolmentSubDocument = false,
                            IsREceiptSubDocument = false
                        },
                        new DocumentType() {
                            ID = 2,
                            Name = "SMS",
                            IsEmail = false,
                            IsPostal = false,
                            IsSMS = true,
                            IsEnrolmentSubDocument = false,
                            IsREceiptSubDocument = false
                        },
                        new DocumentType() {
                            ID = 3,
                            Name = "EnrolmentSubdoc",
                            IsEmail = false,
                            IsPostal = false,
                            IsSMS = false,
                            IsEnrolmentSubDocument = true,
                            IsREceiptSubDocument = false
                        },
                        new DocumentType() {
                            ID = 4,
                            Name = "ReceiptSubdoc",
                            IsEmail = false,
                            IsPostal = false,
                            IsSMS = false,
                            IsEnrolmentSubDocument = false,
                            IsREceiptSubDocument = true
                        });
            modelBuilder.Entity<CourseParticipationType>()
                        .Property(x => x.ID).ValueGeneratedNever();
            modelBuilder.Entity<CourseParticipationType>().HasData(
                        new CourseParticipationType { ID = 0, Name = "Same participants in all classes" },
                        new CourseParticipationType { ID = 1, Name = "Different participants in each class" }
                       );
            modelBuilder.Entity<AttendClassStatus>()
                        .Property(x => x.ID).ValueGeneratedNever();
            modelBuilder.Entity<AttendClassStatus>().HasData(
                        new AttendClassStatus { ID = 0, Status = "Present" },
                        new AttendClassStatus { ID = 1, Status = "Absent without apology" },
                        new AttendClassStatus { ID = 2, Status = "Absent with apology" }
                       );
            modelBuilder.Entity<Occurrence>()
                        .Property(x => x.ID).ValueGeneratedNever();
            modelBuilder.Entity<Occurrence>().HasData(
                        new Occurrence { ID = 0, Name = "Once Only", ShortName = "Once" },
                        new Occurrence { ID = 1, Name = "Daily", ShortName = "Daily" },
                        new Occurrence { ID = 2, Name = "Weekly", ShortName = "Weekly" },
                        new Occurrence { ID = 3, Name = "Fortnightly", ShortName = "F'nightly" },
                        new Occurrence { ID = 4, Name = "1st Week of Month", ShortName = "Week 1" },
                        new Occurrence { ID = 5, Name = "2nd Week of Month", ShortName = "Week 2" },
                        new Occurrence { ID = 6, Name = "3rd Week of Month", ShortName = "Week 3" },
                        new Occurrence { ID = 7, Name = "4th Week of Month", ShortName = "Week 4" },
                        new Occurrence { ID = 8, Name = "Last Week of Month", ShortName = "Last Week" },
                        new Occurrence { ID = 9, Name = "Every 5 Weeks", ShortName = "5 Weeks" },
                        new Occurrence { ID = 10, Name = "Every 6 Weeks", ShortName = "6 Weeks" }
                       );
            modelBuilder.Entity<WeekDay>()
                        .Property(x => x.ID).ValueGeneratedNever();
            modelBuilder.Entity<WeekDay>().HasData(
                        new WeekDay { ID = 0, Day = "Sunday", ShortDay = "Sun" },
                        new WeekDay { ID = 1, Day = "Monday", ShortDay = "Mon" },
                        new WeekDay { ID = 2, Day = "Tuesday", ShortDay = "Tue" },
                        new WeekDay { ID = 3, Day = "Wednesday", ShortDay = "Wed" },
                        new WeekDay { ID = 4, Day = "Thursday", ShortDay = "Thu" },
                        new WeekDay { ID = 5, Day = "Friday", ShortDay = "Fri" },
                        new WeekDay { ID = 6, Day = "Saturday", ShortDay = "Sat" }
                       );

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {
            //    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //    Name = "Security Administrator",
            //    NormalizedName = "Security Administrator".ToUpper()
            //});
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {
            //    Id = "993C6378-61D4-4734-ADAE-D725F2A8CD94",
            //    Name = "System Administrator",
            //    NormalizedName = "System Administrator".ToUpper()
            //});
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {
            //    Id = "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
            //    Name = "Membership",
            //    NormalizedName = "Membership".ToUpper()
            //});
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {
            //    Id = "D4BA57AA-A379-4EE8-940E-57315575978A",
            //    Name = "Accounting",
            //    NormalizedName = "Accounting".ToUpper()
            //});


            ////a hasher to hash the password before seeding the user to the db
            //var hasher = new PasswordHasher<IdentityUser>();

            ////Seeding the User to AspNetUsers table
            //modelBuilder.Entity<IdentityUser>().HasData(
            //    new IdentityUser {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //        Email = "SuperAdmin@U3A.com.au",
            //        NormalizedEmail = "SuperAdmin@U3A.com.au".ToUpper(),
            //        UserName = "SuperAdmin@U3A.com.au",
            //        NormalizedUserName = "SuperAdmin@U3A.com.au".ToUpper(),
            //        EmailConfirmed = true,
            //        PasswordHash = hasher.HashPassword(null, "U3A Rocks!!")
            //    }
            //);

            ////Super Admin has all roles
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string> {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string> {
            //        RoleId = "993C6378-61D4-4734-ADAE-D725F2A8CD94",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string> {
            //        RoleId = "68C1B727-5571-47F4-AAE8-8DC85AB3AEE0",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string> {
            //        RoleId = "D4BA57AA-A379-4EE8-940E-57315575978A",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);


        }
    }
}