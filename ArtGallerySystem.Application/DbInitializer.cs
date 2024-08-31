using Microsoft.Extensions.DependencyInjection;

namespace ArtGallerySystem.Application;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();
        //await unitOfWork.DeleteDataBaseAsync();
        await unitOfWork.CreateDataBaseAsync();
        const string adminEmail = "gigiHadid@gmail.com";
        var admins = await unitOfWork.AdminRepository.ListAllAsync();
        var existingAdmin = admins.FirstOrDefault(a => a.PersonalData.Email == adminEmail);
        if (existingAdmin == null)
        {
            var admin = new Admin(new User("Gigi", "Hadid", adminEmail, "+375295670466", "Ttesting123"));
            await unitOfWork.AdminRepository.AddAsync(admin);
            await unitOfWork.SaveAllAsync();
        }

        const string clientEmail = "bellaHadid@gmail.com";
        var clients = await unitOfWork.ClientRepository.ListAllAsync();
        var existingClient = clients.FirstOrDefault(c => c.PersonalData.Email == clientEmail);
        if (existingClient == null)
        {
            var client = new Client(new User("Bella", "Hadid", clientEmail, "+375333917013", "Ttesting123"));
            await unitOfWork.ClientRepository.AddAsync(client);
            await unitOfWork.SaveAllAsync();
        }
        
        await unitOfWork.SaveAllAsync();
    }
}