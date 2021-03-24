using NotarialOfficeRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.Data
{
    public class DbInitializer
    {
        private static Random randObj = new Random(1);
        public static void Initialize(NotarialOfficeContext db)
        {
            db.Database.EnsureCreated();

            int clientCount = 100;
            int employeeCount = 50;
            int serviceCount = 20;
            int contractCount = 100;

            PositionGenerate(db);
            ClientGenerate(db, clientCount);
            EmployeeGenerate(db, employeeCount);
            ServiceGenerate(db, serviceCount);
            ContractGenerate(db, contractCount);
        }

        private static void PositionGenerate(NotarialOfficeContext db)
        {
            if (db.Positions.Any())
            {
                return;
            }

            db.Positions.AddRange(new Position[]
            {
                new Position()
                {
                    Name = "Notary",
                    Salary = 1000,
                    Duties = "Communication with clients",
                    Requirement = "Communication, diploma"
                },
                new Position()
                {
                    Name = "Assistant notary",
                    Salary = 600,
                    Duties = "Paperwork",
                    Requirement = "Communication, incomplete higher education"
                },
                new Position()
                {
                    Name = "Secretary ",
                    Salary = 400,
                    Duties = "Paperwork",
                    Requirement = "Communication, secondary education"
                },
            });

            db.SaveChanges();
        }

        private static void ClientGenerate(NotarialOfficeContext db, int count)
        {
            if (db.Clients.Any())
            {
                return;
            }

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string[] fullNamesVoc = { "Zhmailik A.V.", "Setko A.I.", "Semenov D.S.", "Davidchik A.E.", "Piskun E.A.",
                                  "Drakula V.A.", "Yastrebov A.A.", "Steponenko Y.A.", "Basharimov Y.I.", "Karkozov V.V." };

            string[] addressVoc = {"Mozyr, per.Zaslonova, ", "Gomel, st.Gastelo, ", "Minsk, st.Poleskay, ", "Grodno, pr.Rechetski, ", "Vitebsk, st, International, ",
                                    "Brest, pr.October, ", "Minsk, st.Basseinaya, ", "Mozyr, boulevard Youth, " };

            for (int i = 0; i < count; i++)
            {
                var fullName = fullNamesVoc[randObj.Next(fullNamesVoc.GetLength(0))] + randObj.Next(count);
                var passportSeries = chars[randObj.Next(chars.Length)].ToString() + chars[randObj.Next(chars.Length)].ToString();
                var passportNum = randObj.Next(100000, 999999);
                var birthdayDate = DateTime.Now.AddDays(-randObj.Next(5000, 10000));
                var address = addressVoc[randObj.Next(addressVoc.GetLength(0))] + randObj.Next(count);
                var phoneNumber = "+375 (29) " + randObj.Next(100, 999) + "-" + randObj.Next(10, 99) +
                              "-" + randObj.Next(10, 99);

                db.Clients.Add(new Client()
                {
                    FullName = fullName,
                    PassportSeries = passportSeries,
                    PassportNumber = passportNum,
                    BirthdayDate = birthdayDate,
                    Address = address,
                    PhoneNumber = phoneNumber
                });
            }
            db.SaveChanges();
        }

        private static void EmployeeGenerate(NotarialOfficeContext db, int count)
        {
            if (db.Employees.Any())
            {
                return;
            }

            int positionCount = db.Positions.Count();

            string[] fullNamesVoc =
            {
                "Lipsky D.Y.", "Stolny S.D.", "Semenov D.S.", "Deker M.A.",
                "Ropot I.V.", "Butkovski Y.V.",
                "Stepanenko Y.V.", "Moiseikov R.A.", "Rogolevich N.V.", "Gerosimenko M.A.",
                "Galetskiy A.A.", "Zankevich K.A."
            };

            string[] addressVoc = {"per.Zaslonova, ", "st.Gastelo, ", "st.Poleskay, ", "pr.Rechetski, ", "st, International, ",
                                    "pr.October, ", "st.Basseinaya, ", "boulevard Youth, " };

            for (int i = 0; i < count; i++)
            {
                var fullName = fullNamesVoc[randObj.Next(fullNamesVoc.GetLength(0))] + randObj.Next(count);
                var birthdayDate = DateTime.Now.AddDays(-randObj.Next(5000, 10000));
                var address = addressVoc[randObj.Next(addressVoc.GetLength(0))] + randObj.Next(count);
                var phoneNumber = "+375 (29) " + randObj.Next(100, 999) + "-" + randObj.Next(10, 99) +
                              "-" + randObj.Next(10, 99);
                var positionId = randObj.Next(1, positionCount + 1);

                db.Employees.Add(new Employee()
                {
                    FullName = fullName,
                    BirthdayDate = birthdayDate,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    PositionId = positionId
                });
            }
            db.SaveChanges();
        }

        private static void ServiceGenerate(NotarialOfficeContext db, int count)
        {
            if (db.Services.Any())
            {
                return;
            }

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
            
            for (int i = 0; i < count; i++)
            {
                var name = new string(Enumerable.Repeat(chars, 20)
                                .Select(s => s[randObj.Next(s.Length)]).ToArray());
                var price = randObj.NextDouble() * 100;
                db.Services.Add(new Service()
                {
                    Name = name,
                    Price = price
                });
            }

            db.SaveChanges();
        }

        private static void ContractGenerate(NotarialOfficeContext db, int count)
        {
            if (db.Contracts.Any())
            {
                return;
            }

            int serviceCount = db.Services.Count();
            int employeeCount = db.Employees.Count();
            int clientCount = db.Clients.Count();

            for (int i = 0; i < count; i++)
            {
                var subDate = DateTime.Now.AddDays(-randObj.Next(1000));
                var endDate = subDate.AddDays(randObj.Next(500));
                var serviceId = randObj.Next(1, serviceCount + 1);
                var employeeId = randObj.Next(1, employeeCount + 1);
                var clientId = randObj.Next(1, clientCount + 1);

                db.Contracts.Add(new Contract()
                {
                    SubscriptDate = subDate,
                    EndDate = endDate,
                    ServiceId = serviceId,
                    EmployeeId = employeeId,
                    ClientId = clientId
                });
            }
            db.SaveChanges();
        }
    }
}
