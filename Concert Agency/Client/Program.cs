using Concert_Agency;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Генерация нового artistId
            Guid artistId = Guid.NewGuid();

            // Передача artistId в конструктор ArtistIdentification
            //Application.Run(new ArtistIdentification(artistId));
            Application.Run(new FillRider(artistId));
        }

    }
}