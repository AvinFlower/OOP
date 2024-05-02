using Tickets_for_the_tour;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

using (TourContext db = new())
{
    //Первая часть--------------------------------------
    Excursion select_excursion(string ExcursionVariants)
    {
        var SelectStudent = db.Excursions
            .Where(b => b.ExcursionVariants == ExcursionVariants)
            .FirstOrDefault();

        return SelectStudent;
    }

    //Ticket select_ticket(int NumberTicket)
    //{
    //    var SelectStudent = db.Tickets
    //        .Where(b => b.NumberTicket == NumberTicket)
    //        .FirstOrDefault();

    //    return SelectStudent;
    //}

    Excursion excursion1 = new Excursion();
    excursion1.Add("Экскурсия на пароме", 200, 3000d, "Река");
    db.Excursions.Add(excursion1);

    Route select_route(Guid ID_Excursion)
    {
        var selectVC = db.Routes
            .Where(b => b.ID_Excursion == ID_Excursion)
            .FirstOrDefault();
        return selectVC;
    }
    db.SaveChanges();

    RoutePoint routePoint1 = new RoutePoint();
    routePoint1.Add(TimeSpan.FromMinutes(34d), select_route(select_excursion("Экскурсия на пароме").Id));
    db.RoutePoints.Add(routePoint1);

    RoutePoint routePoint2 = new RoutePoint();
    routePoint2.Add(TimeSpan.FromMinutes(50d), select_route(select_excursion("Экскурсия на пароме").Id));
    db.RoutePoints.Add(routePoint2);


    Excursion excursion2 = new Excursion();
    excursion2.Add("Краски мирае",1000, 3234d, "Море");
    db.Excursions.Add(excursion2);
    db.SaveChanges();

    RoutePoint routePoint3 = new RoutePoint();
    routePoint3.Add(TimeSpan.FromMinutes(36d), select_route(select_excursion("Краски мирае").Id));
    db.RoutePoints.Add(routePoint3);

    RoutePoint routePoint4 = new RoutePoint();
    routePoint4.Add(TimeSpan.FromMinutes(21d), select_route(select_excursion("Краски мирае").Id));
    db.RoutePoints.Add(routePoint4);


    Excursion excursion3 = new Excursion();
    excursion3.Add("Калейдоскоп", 2000, 5603d, "Поле");
    db.Excursions.Add(excursion3);
    db.SaveChanges();

    RoutePoint routePoint5 = new RoutePoint();
    routePoint5.Add(TimeSpan.FromMinutes(80d), select_route(select_excursion("Калейдоскоп").Id));
    db.RoutePoints.Add(routePoint5);

    RoutePoint routePoint6 = new RoutePoint();
    routePoint6.Add(TimeSpan.FromMinutes(43d), select_route(select_excursion("Калейдоскоп").Id));
    db.RoutePoints.Add(routePoint6);

    Excursion excursion4 = new Excursion();
    excursion4.Add("Миклухо-Маклай", 2500, 1204d, "Лес");
    db.Excursions.Add(excursion4);
    db.SaveChanges();

    RoutePoint routePoint7 = new RoutePoint();
    routePoint7.Add(TimeSpan.FromMinutes(85d), select_route(select_excursion("Миклухо-Маклай").Id));
    db.RoutePoints.Add(routePoint7);

    RoutePoint routePoint8 = new RoutePoint();
    routePoint8.Add(TimeSpan.FromMinutes(38d), select_route(select_excursion("Миклухо-Маклай").Id));
    db.RoutePoints.Add(routePoint8);

    Excursion excursion5 = new Excursion();
    excursion5.Add("Мир странствий", 5000, 4546d, "Горы");
    db.Excursions.Add(excursion5);
    db.SaveChanges();

    RoutePoint routePoint9 = new RoutePoint();
    routePoint9.Add(TimeSpan.FromMinutes(115d), select_route(select_excursion("Мир странствий").Id));
    db.RoutePoints.Add(routePoint9);

    RoutePoint routePoint10 = new RoutePoint();
    routePoint10.Add(TimeSpan.FromMinutes(10d), select_route(select_excursion("Мир странствий").Id));
    db.RoutePoints.Add(routePoint10);


    Attraction attraction1 = new Attraction();
    attraction1.Add("Champ de Mars, 5 Avenue Anatole France, 75007 Paris", "Эйфелева башня", routePoint1);
    db.Attractions.Add(attraction1);

    Attraction attraction2 = new Attraction();
    attraction2.Add("Piazza San Pietro, 00120 Citta del Vaticano", "Собор Святого Петра", routePoint2);
    db.Attractions.Add(attraction2);

    Attraction attraction3 = new Attraction();
    attraction3.Add("Разные участки в разных провинциях Китая", "Большой китайский стена", routePoint3);
    db.Attractions.Add(attraction3);

    Attraction attraction4 = new Attraction();
    attraction4.Add("Al Haram, Nazlet El-Semman, Al Haram, Giza Governorate, Египет", "Пирамиды Гизы", routePoint4);
    db.Attractions.Add(attraction4);

    Attraction attraction5 = new Attraction();
    attraction5.Add("Machu Picchu, 08680, Перу", "Мачу-Пикчу", routePoint5);
    db.Attractions.Add(attraction5);

    Attraction attraction6 = new Attraction();
    attraction6.Add("Liberty Island, New York, NY 10004, США", "Статуя Свободы", routePoint6);
    db.Attractions.Add(attraction6);

    Attraction attraction7 = new Attraction();
    attraction7.Add("Dharmapuri, Forest Colony, Tajganj, Agra, Uttar Pradesh 282001, Индия", "Тадж-Махал", routePoint7);
    db.Attractions.Add(attraction7);

    Attraction attraction8 = new Attraction();
    attraction8.Add("Bennelong Point, Sydney NSW 2000, Австралия", "Сиднейская опера", routePoint8);
    db.Attractions.Add(attraction8);

    Attraction attraction9 = new Attraction();
    attraction9.Add("Piazza del Colosseo, 1, 00184 Roma RM, Италия", "Колизей", routePoint9);
    db.Attractions.Add(attraction9);

    Attraction attraction10 = new Attraction();
    attraction10.Add("Piazza Armerina, 94015 Piazza Armerina EN, Италия", "Вилла-Романа дель Касале", routePoint10);
    db.Attractions.Add(attraction10);


    //Вторая часть--------------------------------------
    Ship ship1 = new Ship();
    ship1.Add("Морской катер", 66, 4, ComfortLevel.Low.ToString());
    db.Ships.Add(ship1);

    Ship ship2 = new Ship();
    ship2.Add("Теплоход", 80, 200, ComfortLevel.Medium.ToString());
    db.Ships.Add(ship2);

    Ship ship3 = new Ship();
    ship3.Add("Лайнер", 10, 2000, ComfortLevel.High.ToString());
    db.Ships.Add(ship3);

    Ship ship4 = new Ship();
    ship4.Add("Круизный корабль", 115, 150000, ComfortLevel.High.ToString());
    db.Ships.Add(ship4);


    Flight flight1 = new Flight();
    flight1.Add(1234, new DateTime(2023,12,09,12,30,0).ToUniversalTime(), "New York", "Miami", TimeSpan.FromDays(5d), excursion1, ship3);
    db.Flights.Add(flight1);

    Flight flight2 = new Flight();
    flight2.Add(2345,new DateTime(2023, 12, 10, 12, 30, 0).ToUniversalTime(), "Los Angeles", "Hawaii", TimeSpan.FromDays(10d), excursion2, ship2);
    db.Flights.Add(flight2);

    Flight flight3 = new Flight();
    flight3.Add(3456,new DateTime(2024, 01, 01, 15, 0, 0).ToUniversalTime(), "Sydney", "Auckland", TimeSpan.FromDays(2d), excursion3, ship1);
    db.Flights.Add(flight3);


    Flight flight6 = new Flight();
    flight6.Add(4567,new DateTime(2024, 01, 01, 15, 30, 30).ToUniversalTime(), "Sydneyyyyyyyyyyy", "Auckland", TimeSpan.FromDays(2d), excursion3, ship1);
    db.Flights.Add(flight6);

    Flight flight4 = new Flight();
    flight4.Add(5678,new DateTime(2024, 04, 19, 9, 30, 0).ToUniversalTime(), "Rome", "Barcelona", TimeSpan.FromDays(30d), excursion4, ship4);
    db.Flights.Add(flight4);

    Flight flight5 = new Flight();
    flight5.Add(6789, new DateTime(2023, 10, 09, 10, 30, 0).ToUniversalTime(), "Paris", "Amsterdam", TimeSpan.FromDays(45d), excursion5, ship4);
    db.Flights.Add(flight5);


    //Третья часть--------------------------------------
    Employee employee1 = new Employee();
    employee1.Add("Пасаженников", "Иван", "Динисович", "3317500467", new DateOnly(2003, 09, 06), Position.Waiter.ToString());
    db.Employees.Add(employee1);

    Employee employee2 = new Employee();
    employee2.Add("Петров", "Петр", "Петрович", "3317500467", new DateOnly(1983, 10, 16), Position.Waiter.ToString());
    db.Employees.Add(employee2);

    Employee employee3 = new Employee();
    employee3.Add("Сидорова", "Мария", "Игоревна", "3395860467", new DateOnly(2001, 02, 26), Position.Waiter.ToString());
    db.Employees.Add(employee3);

    Employee employee4 = new Employee();
    employee4.Add("Смирнов", "Алексей", "Александрович", "3339485767", new DateOnly(2007, 10, 06), Position.Сaptain.ToString());
    db.Employees.Add(employee4);

    Employee employee5 = new Employee();
    employee5.Add("Козлов", "Анна", "Сергеевна", "3203957467", new DateOnly(2004, 09, 15), Position.Сashier.ToString());
    db.Employees.Add(employee5);

    Employee employee6 = new Employee();
    employee6.Add("Михайлов", "Дмитрий", "Андреевич", "3314938467", new DateOnly(2002, 07, 03), Position.Сleaner.ToString());
    db.Employees.Add(employee6);




    Passenger passenger1 = new Passenger();
    passenger1.Add("Динисов", "Антон", "Викторович", "3318600467", new DateOnly(2003, 09, 06), "Россия");
    db.Passes.Add(passenger1);

    Passenger passenger2 = new Passenger();
    passenger2.Add("Васильева", "Ольга", "Павловна", "3128470467", new DateOnly(2000, 10, 26), "Россия");
    db.Passes.Add(passenger2);

    Passenger passenger3 = new Passenger();
    passenger3.Add("Кузнецов", "Андрей", "Владимирович", "334600467", new DateOnly(1999, 12, 06), "Россия");
    db.Passes.Add(passenger3);

    Passenger passenger4 = new Passenger();
    passenger4.Add("Зайцев", "Елена", "Ивановна", "3313400467", new DateOnly(1985, 10, 16), "Россия");
    db.Passes.Add(passenger4);

    Passenger passenger5 = new Passenger();
    passenger5.Add("Павлов", "Сергей", "Алексеевич", "3313500467", new DateOnly(1989, 11, 06), "Россия");
    db.Passes.Add(passenger5);

    Passenger passenger6 = new Passenger();
    passenger6.Add("Новиков", "Артем", "Игоревич", "3313400466", new DateOnly(1995, 05, 22), "Россия");
    db.Passes.Add(passenger6);

    Passenger passenger7 = new Passenger();
    passenger7.Add("Игнатьева", "Татьяна", "Александровна", "3233400467", new DateOnly(1975, 11, 26), "Россия");
    db.Passes.Add(passenger7);

    Passenger passenger8 = new Passenger();
    passenger8.Add("Жуков", "Виктор", "Владимирович", "3563400467", new DateOnly(1965, 11, 06), "Россия");
    db.Passes.Add(passenger8);

    Passenger passenger9 = new Passenger();
    passenger9.Add("Костин", "Максим", "Сергеевич", "3313407867", new DateOnly(1975, 11, 03), "Россия");
    db.Passes.Add(passenger9);

    Passenger passenger10 = new Passenger();
    passenger10.Add("Федоров", "Людмила", "Петровна", "3453400467", new DateOnly(1995, 04, 12), "Россия");
    db.Passes.Add(passenger10);





    Ticket ticket1 = new Ticket();
    ticket1.Add(1,40,new DateTime(2023, 10, 09, 12, 35, 0).ToUniversalTime(), PaymentMethod.Cash.ToString(), passenger1, flight1);
    db.Tickets.Add(ticket1);

    Ticket ticket2 = new Ticket();
    ticket2.Add(2,400, new DateTime(2023, 10, 10, 12, 35, 34).ToUniversalTime(), PaymentMethod.BankTransfer.ToString(), passenger2, flight1);
    db.Tickets.Add(ticket2);

    Ticket ticket3 = new Ticket();
    ticket3.Add(3,390, new DateTime(2023, 10, 11, 14, 55, 55).ToUniversalTime(), PaymentMethod.CreditCard.ToString(), passenger3, flight2);
    db.Tickets.Add(ticket3);

    Ticket ticket4 = new Ticket();
    ticket4.Add(4,4000, new DateTime(2023, 09, 09, 12, 35, 0).ToUniversalTime(), PaymentMethod.Cash.ToString(), passenger4, flight2);
    db.Tickets.Add(ticket4);

    Ticket ticket5 = new Ticket();
    ticket5.Add(5,2090, new DateTime(2023, 08, 10, 11, 11, 11).ToUniversalTime(), PaymentMethod.DebitCard.ToString(), passenger5, flight3);
    db.Tickets.Add(ticket5);

    Ticket ticket6 = new Ticket();
    ticket6.Add(6,1111, new DateTime(2023, 03, 15, 09, 35, 0).ToUniversalTime(), PaymentMethod.BankTransfer.ToString(), passenger6, flight3);
    db.Tickets.Add(ticket6);

    Ticket ticket7 = new Ticket();
    ticket7.Add(7,2345, new DateTime(2023, 05, 019, 17, 55, 0).ToUniversalTime(), PaymentMethod.Cash.ToString(), passenger7, flight4);
    db.Tickets.Add(ticket7);

    Ticket ticket8 = new Ticket();
    ticket8.Add(8,4500, new DateTime(2023, 11, 19, 11, 35, 0).ToUniversalTime(), PaymentMethod.Cash.ToString(), passenger8, flight4);
    db.Tickets.Add(ticket8);

    Ticket ticket9 = new Ticket();
    ticket9.Add(9,1000, new DateTime(2023, 09, 09, 22, 35, 45).ToUniversalTime(), PaymentMethod.CreditCard.ToString(), passenger9, flight5);
    db.Tickets.Add(ticket9);

    Ticket ticket10 = new Ticket();
    ticket10.Add(10,800, new DateTime(2023, 01, 10, 10, 45, 22).ToUniversalTime(), PaymentMethod.Cash.ToString(), passenger10, flight5);
    db.Tickets.Add(ticket10);

    Ticket ticket11 = new Ticket();
    ticket11.Add(11,650, new DateTime(2023, 06, 17, 12, 35, 0).ToUniversalTime(), PaymentMethod.BankTransfer.ToString(), passenger1, flight1);
    db.Tickets.Add(ticket11);

    Ticket ticket12 = new Ticket();
    ticket12.Add(12,200, new DateTime(2023, 12, 25, 21, 03, 56).ToUniversalTime(), PaymentMethod.DebitCard.ToString(), passenger5, flight1);
    db.Tickets.Add(ticket12);

    Payment select_payment(Guid ID_Ticket)
    {
        var selectVC = db.Payments
            .Where(b => b.ID_Ticket == ID_Ticket)
            .FirstOrDefault();
        return selectVC;
    }

    Admin admin = new Admin();
    admin.Add("admin", "123", "Марат");
    db.Admins.Add(admin);

    Admin admin1 = new Admin();
    admin1.Add("admin2", "345", "Сева");
    db.Admins.Add(admin1);



    db.SaveChanges();









}