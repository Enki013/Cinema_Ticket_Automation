# Cinema_Ticket_Automation

## About the Project
The Cinema Ticket Automation system is a Windows Forms application that facilitates ticket sales and management operations for movie theaters.

## Installation
Clone the project:
```bash
git clone https://github.com/Enki013/Cinema_Ticket_Automation.git
```

Open the project with Visual Studio and load the `SinemaTakip.sln` file.

## Usage
To run the application, use the `Main` method in the `Program.cs` file:
```csharp
static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new AnaSayfa());
}
```

## Project Structure
The project consists of the following files and folders:
- `Main.cs`: Main form file.
- `AddFilm.cs`: Form for adding movies.
- `AddSalon.cs`: Form for adding halls.
- `Sales_list.cs`: Form for listing sales.
- `AddSession.cs`: Form for adding sessions.
- `Session_list.cs`: Form for listing sessions.

## Contributing
Please submit a pull request to contribute.

## License
This project is licensed under the MIT License.
