# Beskrivning
Detta är ett startrepository för den examinerande inlämningen i kursen Systemutveckling .NET. Hämta ner detta repository och utgå ifrån det när ni bygger resten av uppgiften i ert egna GitHub konto. Applikationen ska använda sig av headless arkitektur(Client: Blazor WebAssembly Backend: .NET WebApi) med en database first implementation. Ni hittar databasen "BankBlazor.bak" som ska användas under kurstillbehör.



# Setup
**Använd denna connectionstring för DB anslutning:** "Server=localhost;Database=BankBlazor;Trusted_Connection=True;TrustServerCertificate=true;Command Timeout=180"

**Database First Scaffolding:** "Server=localhost;Database=BankBlazor;Trusted_Connection=True;TrustServerCertificate=true;Command Timeout=180" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data



Göm inte att skriva en read me som förklarar appen och de verktyg ni använt er av!(Krav för Godkänt) Denna text är en read me.

BankBlazor är ett grundläggande banksystem där användare kan hantera bankkonton och visa kundprofil. systemet stödjer även olika typer av transaktioner, så som uttag, insättningar och överförnig mellan konton. 

Applikationen är byggd med Blazor för frontend, ASP.Net Core till Backend och Entity Framework Core användes som databashantering.


