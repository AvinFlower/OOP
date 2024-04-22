using Concert_Agency;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;


using (ConcertContext db = new())
{
    //ARTISTS
    Artist artist1 = new Artist();
    artist1.Add("example1@mail.com", "+79123456789", new DateTime(1993, 03, 06, 00, 00, 00).ToUniversalTime(), "USA", "Tyler", "Okonma", "Gregory", "1324_r32324");
    db.Artist.Add(artist1);

    Artist artist2 = new Artist();
    artist2.Add("example2@mail.com", "+44123456789", new DateTime(1985, 09, 12, 00, 00, 00).ToUniversalTime(), "Canada", "Aubrey", "Graham", "", "9876_t56789");
    db.Artist.Add(artist2);

    Artist artist3 = new Artist();
    artist3.Add("example3@mail.com", "+61123456789", new DateTime(1990, 05, 02, 00, 00, 00).ToUniversalTime(), "UK", "Adele", "Adkins", "", "7654_u09876");
    db.Artist.Add(artist3);

    Artist artist4 = new Artist();
    artist4.Add("example4@mail.com", "+81123456789", new DateTime(1981, 12, 18, 00, 00, 00).ToUniversalTime(), "Australia", "Sia", "Furler", "", "3456_i12345");
    db.Artist.Add(artist4);

    Artist artist5 = new Artist();
    artist5.Add("example5@mail.com", "+91123456789", new DateTime(1979, 11, 20, 00, 00, 00).ToUniversalTime(), "Japan", "Hikaru", "Utada", "", "2345_o67890");
    db.Artist.Add(artist5);

    db.SaveChanges();


    //MANAGERS
    Manager manager1 = new Manager();
    manager1.Add("+79123456788", "alice.johnson@mail.com", "Алиса", "Иванова", "Сергеевна", "1234_567890");
    db.Manager.Add(manager1);

    Manager manager2 = new Manager();
    manager2.Add("+44123456787", "bob.doe@mail.com", "Борис", "Петров", "Иванович", "5678_123456");
    db.Manager.Add(manager2);

    Manager manager3 = new Manager();
    manager3.Add("+61123456786", "eva.williams@mail.com", "Евгения", "Смирнова", "Александровна", "9101_234567");
    db.Manager.Add(manager3);

    Manager manager4 = new Manager();
    manager4.Add("+81123456785", "frank.johnson@mail.com", "Франц", "Иванов", "Семенович", "1213_345678");
    db.Manager.Add(manager4);

    Manager manager5 = new Manager();
    manager5.Add("+91123456784", "greta.schmidt@mail.com", "Грета", "Смирнова", "Андреевна", "1516_789012");
    db.Manager.Add(manager5);

    db.SaveChanges();


    //VENUES
    Venue venue1 = new Venue();
    venue1.Add("Madison Square Garden", "New York", "USA");
    db.Venue.Add(venue1);

    Venue venue2 = new Venue();
    venue2.Add("Wembley Stadium", "London", "UK");
    db.Venue.Add(venue2);

    Venue venue3 = new Venue();
    venue3.Add("Sydney Opera House", "Sydney", "Australia");
    db.Venue.Add(venue3);

    Venue venue4 = new Venue();
    venue4.Add("Tokyo Dome", "Tokyo", "Japan");
    db.Venue.Add(venue4);

    Venue venue5 = new Venue();
    venue5.Add("Paris Concert Hall", "Paris", "France");
    db.Venue.Add(venue5);

    db.SaveChanges();


    //CONCERTS
    Concert concert1 = new Concert();
    concert1.Add("LollaPalloza", new DateTime(2024, 03, 14, 15, 30, 0).ToUniversalTime(), venue1, 123456);
    db.Concert.Add(concert1);

    Concert concert2 = new Concert();
    concert2.Add("Wembley Live", new DateTime(2024, 05, 20, 18, 0, 0).ToUniversalTime(), venue2, 200000);
    db.Concert.Add(concert2);

    Concert concert3 = new Concert();
    concert3.Add("Opera Spectacle", new DateTime(2024, 07, 10, 19, 30, 0).ToUniversalTime(), venue3, 80000);
    db.Concert.Add(concert3);

    Concert concert4 = new Concert();
    concert4.Add("Tokyo Harmony", new DateTime(2024, 09, 5, 20, 0, 0).ToUniversalTime(), venue4, 150000);
    db.Concert.Add(concert4);

    Concert concert5 = new Concert();
    concert5.Add("Paris Serenade", new DateTime(2024, 11, 15, 21, 0, 0).ToUniversalTime(), venue5, 100000);
    db.Concert.Add(concert5);

    db.SaveChanges();


    //CONCERTMANAGERS
    ConcertManager concertManager1 = new ConcertManager();
    concertManager1.Add(concert1, "Безопасность", manager1);
    db.ConcertManager.Add(concertManager1);

    ConcertManager concertManager2 = new ConcertManager();
    concertManager2.Add(concert2, "Тех. Менеджер", manager2);
    db.ConcertManager.Add(concertManager2);

    ConcertManager concertManager3 = new ConcertManager();
    concertManager3.Add(concert3, "Тех. Менеджер", manager3);
    db.ConcertManager.Add(concertManager3);

    ConcertManager concertManager4 = new ConcertManager();
    concertManager4.Add(concert4, "Главный менеджер", manager4);
    db.ConcertManager.Add(concertManager4);

    ConcertManager concertManager5 = new ConcertManager();
    concertManager5.Add(concert5, "Безопасность", manager5);
    db.ConcertManager.Add(concertManager5);

    db.SaveChanges();


    //ORDERS
    Order order1 = new Order();
    order1.Add(1, DateTime.UtcNow, "Completed", artist1, manager1);
    artist1.Orders.Add(order1);
    manager1.Orders.Add(order1);
    db.Artist.Update(artist1);
    db.Manager.Update(manager1);
    db.Order.Update(order1);

    Order order2 = new Order();
    order2.Add(2, DateTime.UtcNow.AddMinutes(400), "Completed", artist2, manager2);
    artist2.Orders.Add(order2);
    manager2.Orders.Add(order2);
    db.Artist.Update(artist2);
    db.Manager.Update(manager2);
    db.Order.Update(order2);

    Order order3 = new Order();
    order3.Add(3, DateTime.UtcNow.AddMinutes(600), "In Process", artist3, manager3);
    artist3.Orders.Add(order3);
    manager3.Orders.Add(order3);
    db.Artist.Update(artist3);
    db.Manager.Update(manager3);
    db.Order.Update(order3);

    Order order4 = new Order();
    order4.Add(4, DateTime.UtcNow.AddMinutes(900), "In Process", artist4, manager4);
    artist4.Orders.Add(order4);
    manager4.Orders.Add(order4);
    db.Artist.Update(artist4);
    db.Manager.Update(manager4);
    db.Order.Update(order4);

    Order order5 = new Order();
    order5.Add(5, DateTime.UtcNow.AddMinutes(1000), "Preparation", artist5, manager5);
    artist5.Orders.Add(order5);
    manager5.Orders.Add(order5);
    db.Artist.Update(artist5);
    db.Manager.Update(manager5);
    db.Order.Update(order5);

    Order order6 = new Order();
    order6.Add(6, DateTime.UtcNow.AddMinutes(1200), "Preparation", artist1, manager1);
    artist1.Orders.Add(order6);
    manager1.Orders.Add(order6);
    db.Artist.Update(artist1);
    db.Manager.Update(manager1);
    db.Order.Update(order6);

    Order order7 = new Order();
    order7.Add(7, DateTime.UtcNow.AddMinutes(1300), "Preparation", artist2, manager2);
    artist2.Orders.Add(order7);
    manager2.Orders.Add(order7);
    db.Artist.Update(artist2);
    db.Manager.Update(manager2);
    db.Order.Update(order7);

    Order order8 = new Order();
    order8.Add(8, DateTime.UtcNow.AddMinutes(1500), "Preparation", artist3, manager3);
    artist3.Orders.Add(order8);
    manager3.Orders.Add(order8);
    db.Artist.Update(artist3);
    db.Manager.Update(manager3);
    db.Order.Update(order8);

    db.SaveChanges();


    //TICKETS
    Ticket ticket1 = new Ticket();
    ticket1.Add("113", "Стандарт, 199$", new DateTime(2024, 03, 14, 15, 30, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket1);

    Ticket ticket2 = new Ticket();
    ticket2.Add("234", "VIP, 1249$", new DateTime(2024, 03, 14, 15, 30, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket2);

    Ticket ticket3 = new Ticket();
    ticket3.Add("305", "Комфорт, 399$", new DateTime(2024, 03, 14, 15, 30, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket3);

    Ticket ticket4 = new Ticket();
    ticket4.Add("400", "Первый класс, 699", new DateTime(2024, 03, 14, 15, 30, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket4);

    Ticket ticket5 = new Ticket();
    ticket5.Add("105", "Стандарт, 199$", new DateTime(2024, 03, 14, 15, 31, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket5);

    Ticket ticket6 = new Ticket();
    ticket6.Add("61", "Стандарт, 199$", new DateTime(2024, 03, 14, 16, 32, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket6);

    Ticket ticket7 = new Ticket();
    ticket7.Add("799", "Стандарт, 199$", new DateTime(2024, 03, 15, 15, 33, 0).ToUniversalTime(), concert1);
    db.Ticket.Add(ticket7);

    db.SaveChanges();


    //CONCERTARTISTS
    ConcertArtist concertArtist1 = new ConcertArtist();
    concertArtist1.Add(concert1, artist1);
    artist1.ConcertArtists.Add(concertArtist1);
    concert1.ConcertArtists.Add(concertArtist1);
    db.Artist.Update(artist1);
    db.Concert.Update(concert1);
    db.ConcertArtist.Add(concertArtist1);

    ConcertArtist concertArtist2 = new ConcertArtist();
    concertArtist2.Add(concert2, artist2);
    artist2.ConcertArtists.Add(concertArtist2);
    concert2.ConcertArtists.Add(concertArtist2);
    db.Artist.Update(artist2);
    db.Concert.Update(concert2);
    db.ConcertArtist.Add(concertArtist2);

    ConcertArtist concertArtist3 = new ConcertArtist();
    concertArtist3.Add(concert3, artist3);
    artist3.ConcertArtists.Add(concertArtist3);
    concert3.ConcertArtists.Add(concertArtist3);
    db.Artist.Update(artist3);
    db.Concert.Update(concert3);
    db.ConcertArtist.Add(concertArtist3);

    ConcertArtist concertArtist4 = new ConcertArtist();
    concertArtist4.Add(concert4, artist4);
    artist4.ConcertArtists.Add(concertArtist4);
    concert4.ConcertArtists.Add(concertArtist4);
    db.Artist.Update(artist4);
    db.Concert.Update(concert4);
    db.ConcertArtist.Add(concertArtist4);

    ConcertArtist concertArtist5 = new ConcertArtist();
    concertArtist5.Add(concert5, artist5);
    artist5.ConcertArtists.Add(concertArtist5);
    concert5.ConcertArtists.Add(concertArtist5);
    db.Artist.Update(artist5);
    db.Concert.Update(concert5);
    db.ConcertArtist.Add(concertArtist5);

    db.SaveChanges();


    //RIDERS
    Rider rider1 = new Rider();
    rider1.Add("Звуковая система: JBL, 1200 Вт, Безопасность: Профессиональная служба безопасности", DateTime.UtcNow, artist1);
    db.Rider.Add(rider1);

    Rider rider2 = new Rider();
    rider2.Add("Гитара: Fender Jazz Bass, Клавишные: Yamaha D3X", DateTime.UtcNow.AddMinutes(786), artist2);
    db.Rider.Add(rider2);

    Rider rider3 = new Rider();
    rider3.Add("Вместимость зала: 10000 человек, Микшерный пульт: Behringer, 24 канала, Бас-гитара: Fender Jazz Bass", DateTime.UtcNow.AddMinutes(1713), artist3);
    db.Rider.Add(rider3);

    Rider rider4 = new Rider();
    rider4.Add("Микрофон: Shure SM58, 3 шт.", DateTime.UtcNow.AddMinutes(2126), artist4);
    db.Rider.Add(rider4);

    Rider rider5 = new Rider();
    rider5.Add("Клавишные: Mini Moog", DateTime.UtcNow.AddMinutes(4000), artist5);
    db.Rider.Add(rider5);

    db.SaveChanges();


    //TECHNICALPARAMETERS
    TechnicalParameters technicalParameters1 = new TechnicalParameters();
    technicalParameters1.Add("Звуковая система");
    db.TechnicalParameter.Add(technicalParameters1);

    TechnicalParameters technicalParameters2 = new TechnicalParameters();
    technicalParameters2.Add("Микшерный пульт");
    db.TechnicalParameter.Add(technicalParameters2);

    TechnicalParameters technicalParameters3 = new TechnicalParameters();
    technicalParameters3.Add("Микрофон");
    db.TechnicalParameter.Add(technicalParameters3);

    TechnicalParameters technicalParameters4 = new TechnicalParameters();
    technicalParameters4.Add("Клавишные");
    db.TechnicalParameter.Add(technicalParameters4);

    TechnicalParameters technicalParameters5 = new TechnicalParameters();
    technicalParameters5.Add("Гитара");
    db.TechnicalParameter.Add(technicalParameters5);

    TechnicalParameters technicalParameters6 = new TechnicalParameters();
    technicalParameters6.Add("Декорации");
    db.TechnicalParameter.Add(technicalParameters6);

    TechnicalParameters technicalParameters7 = new TechnicalParameters();
    technicalParameters7.Add("Безопасность");
    db.TechnicalParameter.Add(technicalParameters7);

    TechnicalParameters technicalParameters8 = new TechnicalParameters();
    technicalParameters8.Add("Вместимость зала");
    db.TechnicalParameter.Add(technicalParameters8);

    TechnicalParameters technicalParameters9 = new TechnicalParameters();
    technicalParameters9.Add("Проживание");
    db.TechnicalParameter.Add(technicalParameters9);

    db.SaveChanges();


    //RIDERREQUESTS
    RiderRequest riderRequest1 = new RiderRequest();
    riderRequest1.Add("1", "Звуковая система: JBL, 1200 Вт", rider1, technicalParameters1);
    rider1.RidersRequests.Add(riderRequest1);
    db.Rider.Update(rider1);
    db.RiderRequest.Update(riderRequest1);

    RiderRequest riderRequest11 = new RiderRequest();
    riderRequest11.Add("1", "Безопасность: Профессиональная служба безопасности", rider1, technicalParameters7);
    rider1.RidersRequests.Add(riderRequest11);
    db.Rider.Update(rider1);
    db.RiderRequest.Update(riderRequest11);


    RiderRequest riderRequest2 = new RiderRequest();
    riderRequest2.Add("2", "Гитара: Fender Jazz Bass", rider2, technicalParameters5);
    rider2.RidersRequests.Add(riderRequest2);
    db.Rider.Update(rider2);
    db.RiderRequest.Update(riderRequest2);
    
    RiderRequest riderRequest22 = new RiderRequest();
    riderRequest22.Add("2", "Клавишные: Yamaha D3X", rider2, technicalParameters4);
    rider2.RidersRequests.Add(riderRequest22);
    db.Rider.Update(rider2);
    db.RiderRequest.Update(riderRequest22);


    RiderRequest riderRequest3 = new RiderRequest();
    riderRequest3.Add("3", "Вместимость зала: 10000 человек", rider3, technicalParameters8);
    rider3.RidersRequests.Add(riderRequest3);
    db.Rider.Update(rider3);
    db.RiderRequest.Update(riderRequest3);
    
    RiderRequest riderRequest33 = new RiderRequest();
    riderRequest33.Add("3", "Микшерный пульт: Behringer, 24 канала", rider3, technicalParameters2);
    rider3.RidersRequests.Add(riderRequest33);
    db.Rider.Update(rider3);
    db.RiderRequest.Update(riderRequest33);
    
    RiderRequest riderRequest333 = new RiderRequest();
    riderRequest333.Add("3", "Гитара: Fender Jazz Bass", rider3, technicalParameters5);
    rider3.RidersRequests.Add(riderRequest333);
    db.Rider.Update(rider3);
    db.RiderRequest.Update(riderRequest333);


    RiderRequest riderRequest4 = new RiderRequest();
    riderRequest4.Add("4", "Микрофон: Shure SM58, 3 шт.", rider4, technicalParameters3);
    rider4.RidersRequests.Add(riderRequest4);
    db.Rider.Update(rider4);
    db.RiderRequest.Update(riderRequest4);


    RiderRequest riderRequest5 = new RiderRequest();
    riderRequest5.Add("5", "Клавишные: Mini Moog", rider5, technicalParameters4);
    rider5.RidersRequests.Add(riderRequest5);
    db.Rider.Update(rider5);
    db.RiderRequest.Update(riderRequest5);

    db.SaveChanges();


    //ORGANIZATIONALREQUESTS
    OrganizationalRequest organizationalRequest1 = new OrganizationalRequest();
    organizationalRequest1.Add("JBL, 2000 Вт", technicalParameters1, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest1);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest1);

    OrganizationalRequest organizationalRequest2 = new OrganizationalRequest();
    organizationalRequest2.Add("Behringer X32, 32 канала", technicalParameters2, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest2);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest2);

    OrganizationalRequest organizationalRequest3 = new OrganizationalRequest();
    organizationalRequest3.Add("Shure SM58, 5 штук", technicalParameters3, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest3);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest3);

    OrganizationalRequest organizationalRequest4 = new OrganizationalRequest();
    organizationalRequest4.Add("Yamaha CP88", technicalParameters4, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest4);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest4);

    OrganizationalRequest organizationalRequest5 = new OrganizationalRequest();
    organizationalRequest5.Add("Fender Jazz Bass", technicalParameters5, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest5);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest5);

    OrganizationalRequest organizationalRequest6 = new OrganizationalRequest();
    organizationalRequest6.Add("Сценические декорации в стиле рок", technicalParameters6, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest6);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest6);

    OrganizationalRequest organizationalRequest7 = new OrganizationalRequest();
    organizationalRequest7.Add("Два телохранителя", technicalParameters7, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest7);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest7);

    OrganizationalRequest organizationalRequest8 = new OrganizationalRequest();
    organizationalRequest8.Add("5000 человек", technicalParameters8, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest8);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest8);

    OrganizationalRequest organizationalRequest9 = new OrganizationalRequest();
    organizationalRequest9.Add("5 звезд, все включено", technicalParameters9, venue1);
    venue1.OrganizationalRequests.Add(organizationalRequest9);
    db.Venue.Update(venue1);
    db.OrganizationalRequest.Update(organizationalRequest9);





    OrganizationalRequest organizationalRequest10 = new OrganizationalRequest(); 
    organizationalRequest10.Add("Bose, 3000 Вт", technicalParameters1, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest10);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest10);

    OrganizationalRequest organizationalRequest11 = new OrganizationalRequest(); 
    organizationalRequest11.Add("Midas M32, 40 каналов", technicalParameters2, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest11);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest11);

    OrganizationalRequest organizationalRequest12 = new OrganizationalRequest(); 
    organizationalRequest12.Add("AKG P240, 6 штук", technicalParameters3, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest12);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest12);

    OrganizationalRequest organizationalRequest13 = new OrganizationalRequest(); 
    organizationalRequest13.Add("Roland RD-2000", technicalParameters4, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest13);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest13);

    OrganizationalRequest organizationalRequest14 = new OrganizationalRequest(); 
    organizationalRequest14.Add("Music Man Bongo 6 HS, 6 струн", technicalParameters5, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest14);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest14);

    OrganizationalRequest organizationalRequest15 = new OrganizationalRequest(); 
    organizationalRequest15.Add("Лес и полнолуние", technicalParameters6, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest15);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest15);

    OrganizationalRequest organizationalRequest16 = new OrganizationalRequest(); 
    organizationalRequest16.Add("Специализированная охрана", technicalParameters7, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest16);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest16);

    OrganizationalRequest organizationalRequest17 = new OrganizationalRequest(); 
    organizationalRequest17.Add("12000 человек", technicalParameters8, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest17);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest17);

    OrganizationalRequest organizationalRequest18 = new OrganizationalRequest(); 
    organizationalRequest18.Add("Отель Royal", technicalParameters9, venue2);
    venue2.OrganizationalRequests.Add(organizationalRequest18);
    db.Venue.Update(venue2);
    db.OrganizationalRequest.Update(organizationalRequest18);






    OrganizationalRequest organizationalRequest19 = new OrganizationalRequest();
    organizationalRequest19.Add("JBL, 2000 Вт", technicalParameters1, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest19);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest19);

    OrganizationalRequest organizationalRequest20 = new OrganizationalRequest();
    organizationalRequest20.Add("Behringer X32, 32 канала", technicalParameters2, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest20);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest20);

    OrganizationalRequest organizationalRequest21 = new OrganizationalRequest();
    organizationalRequest21.Add("Shure SM58, 5 штук", technicalParameters3, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest21);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest21);

    OrganizationalRequest organizationalRequest22 = new OrganizationalRequest();
    organizationalRequest22.Add("Yamaha CP88", technicalParameters4, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest22);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest22);

    OrganizationalRequest organizationalRequest23 = new OrganizationalRequest();
    organizationalRequest23.Add("Fender Jazz Bass", technicalParameters5, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest23);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest23);

    OrganizationalRequest organizationalRequest24 = new OrganizationalRequest();
    organizationalRequest24.Add("Сценические декорации в стиле рок", technicalParameters6, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest24);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest24);

    OrganizationalRequest organizationalRequest25 = new OrganizationalRequest();
    organizationalRequest25.Add("Все", technicalParameters7, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest25);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest25);

    OrganizationalRequest organizationalRequest26 = new OrganizationalRequest();
    organizationalRequest26.Add("5000 человек", technicalParameters8, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest26);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest26);

    OrganizationalRequest organizationalRequest27 = new OrganizationalRequest();
    organizationalRequest27.Add("Grand Palace Hotel", technicalParameters9, venue3);
    venue3.OrganizationalRequests.Add(organizationalRequest27);
    db.Venue.Update(venue3);
    db.OrganizationalRequest.Update(organizationalRequest27);






    OrganizationalRequest organizationalRequest28 = new OrganizationalRequest();
    organizationalRequest28.Add("Yamaha, 2500 Вт", technicalParameters1, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest28);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest28);

    OrganizationalRequest organizationalRequest29 = new OrganizationalRequest();
    organizationalRequest29.Add("Soundcraft Vi3000, 36 каналов", technicalParameters2, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest29);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest29);

    OrganizationalRequest organizationalRequest30 = new OrganizationalRequest();
    organizationalRequest30.Add("Sennheiser e835, 7 штук", technicalParameters3, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest30);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest30);

    OrganizationalRequest organizationalRequest31 = new OrganizationalRequest();
    organizationalRequest31.Add("Korg Kronos", technicalParameters4, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest31);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest31);

    OrganizationalRequest organizationalRequest32 = new OrganizationalRequest();
    organizationalRequest32.Add("Ernie Ball Music Man StingRay", technicalParameters5, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest32);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest32);

    OrganizationalRequest organizationalRequest33 = new OrganizationalRequest();
    organizationalRequest33.Add("Световое шоу", technicalParameters6, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest33);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest33);

    OrganizationalRequest organizationalRequest34 = new OrganizationalRequest();
    organizationalRequest34.Add("Охрана и медицинский персонал", technicalParameters7, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest34);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest34);

    OrganizationalRequest organizationalRequest35 = new OrganizationalRequest();
    organizationalRequest35.Add("8000 человек", technicalParameters8, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest35);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest35);

    OrganizationalRequest organizationalRequest36 = new OrganizationalRequest();
    organizationalRequest36.Add("Гостиница Lux", technicalParameters9, venue4);
    venue4.OrganizationalRequests.Add(organizationalRequest36);
    db.Venue.Update(venue4);
    db.OrganizationalRequest.Update(organizationalRequest36);






    OrganizationalRequest organizationalRequest37 = new OrganizationalRequest();
    organizationalRequest37.Add("Aqua Control 2, 4000 Вт", technicalParameters1, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest37);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest37);

    OrganizationalRequest organizationalRequest38 = new OrganizationalRequest();
    organizationalRequest38.Add("Behringer XR18, 18 каналов", technicalParameters2, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest38);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest38);

    OrganizationalRequest organizationalRequest39 = new OrganizationalRequest();
    organizationalRequest39.Add("Audio-Technica AT2020, 8 штук", technicalParameters3, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest39);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest39);

    OrganizationalRequest organizationalRequest40 = new OrganizationalRequest();
    organizationalRequest40.Add("Kawai MP11SE", technicalParameters4, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest40);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest40);

    OrganizationalRequest organizationalRequest41 = new OrganizationalRequest();
    organizationalRequest41.Add("Fender Precision Bass", technicalParameters5, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest41);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest41);

    OrganizationalRequest organizationalRequest42 = new OrganizationalRequest();
    organizationalRequest42.Add("Пиротехнические эффекты", technicalParameters6, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest42);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest42);

    OrganizationalRequest organizationalRequest43 = new OrganizationalRequest();
    organizationalRequest43.Add("Фирменная охрана", technicalParameters7, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest43);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest43);

    OrganizationalRequest organizationalRequest44 = new OrganizationalRequest();
    organizationalRequest44.Add("15000 человек", technicalParameters8, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest44);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest44);

    OrganizationalRequest organizationalRequest45 = new OrganizationalRequest();
    organizationalRequest45.Add("Гостиница Grand", technicalParameters9, venue5);
    venue5.OrganizationalRequests.Add(organizationalRequest45);
    db.Venue.Update(venue5);
    db.OrganizationalRequest.Update(organizationalRequest45);


    db.SaveChanges();


    //AUTHENTICATIONS
    Authentication authentication1 = new Authentication();
    authentication1.Add("user1", "userp1", artist1);
    artist1.Authentications.Add(authentication1);
    db.Authentication.Update(authentication1);
    db.Artist.Update(artist1);

    Authentication authentication2 = new Authentication();
    authentication2.Add("user2", "userp2", artist2);
    artist2.Authentications.Add(authentication2);
    db.Authentication.Update(authentication2);
    db.Artist.Update(artist2);

    Authentication authentication3 = new Authentication();
    authentication3.Add("user3", "userp3", artist3);
    artist3.Authentications.Add(authentication3);
    db.Authentication.Update(authentication3);
    db.Artist.Update(artist3);

    Authentication authentication4 = new Authentication();
    authentication4.Add("user4", "userp4", artist4);
    artist4.Authentications.Add(authentication4);
    db.Authentication.Update(authentication4);
    db.Artist.Update(artist4);

    Authentication authentication5 = new Authentication();
    authentication5.Add("user5", "userp5", artist5);
    artist5.Authentications.Add(authentication5);
    db.Authentication.Update(authentication5);
    db.Artist.Update(artist5);

    db.SaveChanges();
}