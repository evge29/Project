using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace Project.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                new Clients
                {
                    FirstName = "Marija",
                    LastName = "Markoska",
                    EnrollmentDate = DateTime.Parse("2017-09-15"),
                    Мembership = false

                },
                new Clients
                {
                    FirstName = "Simona",
                    LastName = "Simonoska",
                    EnrollmentDate = DateTime.Parse("2016-09-15"),
                    Мembership = true

                },
                new Clients
                {
                    FirstName = "Aleksandra",
                    LastName = "Atanasoska",
                    EnrollmentDate = DateTime.Parse("2016-09-15"),
                    Мembership = true
                },
                new Clients
                {
                    FirstName = "Andrej",
                    LastName = "Andreevski",
                    EnrollmentDate = DateTime.Parse("2017-09-15"),
                    Мembership = true
                },
                new Clients
                {
                    FirstName = "Angela",
                    LastName = "Angeloska",
                    EnrollmentDate = DateTime.Parse("2017-09-15"),
                    Мembership = true
                },
                new Clients
                {
                    FirstName = "Marko",
                    LastName = "Markoski",
                    EnrollmentDate = DateTime.Parse("2015-09-15"),
                    Мembership = true
                },
                new Clients
                {
                    FirstName = "Stefan",
                    LastName = "Stefanoski",
                    EnrollmentDate = DateTime.Parse("2018-09-15"),
                    Мembership = true
                },
                new Clients
                {
                    FirstName = "Stefani",
                    LastName = "Stefanoska",
                    EnrollmentDate = DateTime.Parse("2017-09-15"),
                    Мembership = true
                }
            );
                }
                if (!context.Coaches.Any())
                {
                    context.Coaches.AddRange(
                         new Coaches
                         {
                             FirstName = "Tale",
                             LastName = "Trajkov",
                             Certificate = true,
                             HireDate = DateTime.Parse("2010-05-12")
                         },
                    new Coaches
                    {
                        FirstName = "Viktorija",
                        LastName = "Ackova",
                        Certificate = true,
                        HireDate = DateTime.Parse("2009-10-25")
                    },
                    new Coaches
                    {
                        FirstName = "Vladimir",
                        LastName = "Petrovski",
                        Certificate = true,
                        HireDate = DateTime.Parse("2012-10-10")
                    },
                    new Coaches
                    {
                        FirstName = "Simona",
                        LastName = "Baseska",
                        Certificate = true,
                        HireDate = DateTime.Parse("2007-03-20")
                    },
                    new Coaches
                    {
                        FirstName = "Marko",
                        LastName = "Velevackovski",
                        Certificate = false,
                        HireDate = DateTime.Parse("2015-09-06")
                    },
                    new Coaches
                    {
                        FirstName = "Lazar",
                        LastName = "Nikolov",
                        Certificate = true,
                        HireDate = DateTime.Parse("2016-06-10")
                    },
                    new Coaches
                    {
                        FirstName = "Kristijan",
                        LastName = "Kimovski",
                        Certificate = true,
                        HireDate = DateTime.Parse("2012-07-10")
                    }
                   );
                }
                if (!context.Programs.Any())
                {
                    context.Programs.AddRange(
                       new Programs
                       {
                           Name = "InstaBOOTY",
                           Payment = "50$",
                           Duration = "6 meseci",
                           CoachId = context.Coaches.Single(d => d.FirstName == "Tale" && d.LastName == "Trajkov").Id
                       },
                       new Programs
                       {
                           Name = "InstaFIT",
                           Payment = "30$",
                           Duration = "3 meseci",
                           CoachId = context.Coaches.Single(d => d.FirstName == "Viktorija" && d.LastName == "Ackova").Id
                       },
                       new Programs
                       {
                           Name = "HIIT",
                           Payment = "100$",
                           Duration = "6 meseci",
                           CoachId = context.Coaches.Single(d => d.FirstName == "Vladimir" && d.LastName == "Petrovski").Id
                       },
                       new Programs
                       {
                           Name = "FULL BODY",
                           Payment = "50$",
                           Duration = "2 meseci",
                           CoachId = context.Coaches.Single(d => d.FirstName == "Simona" && d.LastName == "Baseska").Id
                       },
                       new Programs
                       {
                           Name = "SPLIT BODY",
                           Payment = "30$",
                           Duration = "1 meseci",
                           CoachId = context.Coaches.Single(d => d.FirstName == "Lazar" && d.LastName == "Nikolov").Id
                       },

                       new Programs
                       {
                           Name = "BODY PERFECTION",
                           Payment = "80$",
                           Duration = "3 meseci",
                           CoachId = context.Coaches.Single(d => d.FirstName == "Marko" && d.LastName == "Velevackovski").Id
                       }
                       );
                }




                if (!context.Enrollment.Any())
                {
                    context.Enrollment.AddRange(
                        new Enrollment
                        {
                            ProgramId = context.Programs.Single(x=> x.Name == "BODY PERFECTION").Id,
                            ClientId = context.Clients.Single(x=> x.FirstName == "Stefan").Id,
                            InitialWeight = 87,
                            FinalWeight = 70,
                            FinishDate = DateTime.Parse("2020-01-28")
                        },
                        new Enrollment
                        {
                            ProgramId = context.Programs.Single(x => x.Name == "SPLIT BODY").Id,
                            ClientId = context.Clients.Single(x => x.FirstName == "Stefani").Id,
                            InitialWeight = 55,
                            FinalWeight = 60,
                            FinishDate = DateTime.Parse("2019-06-28")
                        },
                        new Enrollment
                        {
                            ProgramId = context.Programs.Single(x => x.Name == "FULL BODY").Id,
                            ClientId = context.Clients.Single(x => x.FirstName == "Marko").Id,
                            InitialWeight = 60,
                            FinalWeight = 55,
                            FinishDate = DateTime.Parse("2019-06-06")
                        },
                        new Enrollment
                        {
                            ProgramId = context.Programs.Single(x => x.Name == "InstaBOOTY").Id,
                            ClientId = context.Clients.Single(x => x.FirstName == "Aleksandra").Id,
                            InitialWeight = 100,
                            FinalWeight = 80,
                            FinishDate = DateTime.Parse("2020-01-20")
                        },
                        new Enrollment
                        {
                            ProgramId = context.Programs.Single(x => x.Name == "HIIT").Id,
                            ClientId = context.Clients.Single(x => x.FirstName == "Andrej").Id,
                            InitialWeight = 85,
                            FinalWeight = 73,
                            FinishDate = DateTime.Parse("2019-01-25")
                        },
                        new Enrollment
                        {
                            ProgramId = context.Programs.Single(x => x.Name == "InstaFIT").Id,
                            ClientId = context.Clients.Single(x => x.FirstName == "Marija").Id,
                            InitialWeight = 130,
                            FinalWeight = 95,
                            FinishDate = DateTime.Parse("2019-02-01")
                        }
                        );
                }
                context.SaveChanges();
            }

        }

    }
}