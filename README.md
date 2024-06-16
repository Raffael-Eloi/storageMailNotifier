# storageMailNotifier 🚀

## Idea 💡
The `storageMailNotifier` is a .NET application designed to automatically send an email notification whenever a new file is uploaded to Azure Blob Storage.

## Requirements 🗹
- **Unit Testing:** Use [NSubstitute](https://nsubstitute.github.io/)
- **Validation:** Use [FluentValidation](https://fluentvalidation.net/) for input and notification validation
- **Email Sending:** Use SMTP to send emails
- **Infrastructure as Code:** Use Terraform to create and manage the Azure Function infrastructure

## Goals 🎯
- **Azure Functions:** Learn how to create and deploy an Azure Function
- **Azure Resources:** Explore advanced Azure resources and their integration
- **SMTP:** Gain a deeper understanding of SMTP and its configurations
- **Notification Libraries:** Learn about FluentValidation for handling notifications
- **Mock Libraries:** Gain experience with NSubstitute for unit testing
- **Infrastructure Automation:** Learn how to use Terraform with Azure

## Flow 🌀
![Flow Diagram](https://github.com/Raffael-Eloi/storageMailNotifier/assets/51720161/defd422a-45d5-43af-8a99-258ac456ffcd)

## Architecture 📝
![image](https://github.com/Raffael-Eloi/storageMailNotifier/assets/51720161/f74621fe-1daa-4646-a25d-6587802ecd8f)

## Prerequisites ✅

Before running the `Blob.Storage.Listener` project, ensure you have the following prerequisites installed:

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- An [Azure Blob Storage](https://azure.microsoft.com/en-us/services/storage/blobs/) account

## Getting Started 💻

Follow these steps to get the project up and running:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Raffael-Eloi/storageMailNotifier.git
   cd storageMailNotifier
   ```

2. **Setup Azure Blob Storage:**
   - Create an Azure Blob Storage account if you don't already have one.
   - Note down the connection string for the storage account.

3. **Configure the application:**
   - Update the `appsettings.json` or environment variables with your Azure Blob Storage connection string and SMTP settings.

4. **Deploy using Terraform:**
   - Navigate to the [storageMailNotifierFunction](https://github.com/Raffael-Eloi/storageMailNotifierFunction) repository for Terraform configuration.
   - Follow the instructions to provision the required Azure resources.

5. **Run the application:**
   ```bash
   cd src/Blob.Storage.Listner
   dotnet run
   ```

6. **Running locally:**
   - Add a file named `local.settings.json` with the following content
   ```json
   {
    "IsEncrypted": false,
    "Values": {
      "AzureWebJobsStorage": "YOUR_STORAGE_ACCOUNT_CONTAINER_CONNECTION_STRING",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
      "WEBSITE_RUN_FROM_PACKAGE": true
      }
   }
   ```

## Terraform 🖥️
For provisioning the necessary infrastructure, refer to the [storageMailNotifierFunction](https://github.com/Raffael-Eloi/storageMailNotifierFunction) repository.

## License 

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
