using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Transactions;

using (ConcertContext db = new())
{
    //Client client1 = new Client();
    //client1.Add("kurwa@mail.ru", "+79127465666", "Россия,г. Киров, ул. Молодой Гвардии, д. 48, кв. 12", "Матвей", "Мышкин", "Алексеевич", "3318_510245");
    //db.Clients.Add(client1);

    //Order order1 = new Order();
    //order1.Add(new DateTime(2023, 12, 10, 12, 35, 0), );
    //db.Clients.Add(client1);

    db.SaveChanges();
}