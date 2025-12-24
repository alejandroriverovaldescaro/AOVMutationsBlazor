# AOV Mutatie Aanvragen - Blazor Server Starter Kit

Een Blazor Server applicatie voor het beheren van AOV (Arbeidsongeschiktheidsverzekering) mutatie aanvragen volgens het SZV-PRIS schema.

## Projectstructuur

```
AOVMutationsBlazor/
├── AOVMutationsBlazor.sln
├── AOVMutationsBlazor.Data/          # EF Core models en DbContext
│   ├── Models/
│   │   ├── MutationRequest.cs
│   │   ├── Person.cs
│   │   ├── Address.cs
│   │   └── Employment.cs
│   └── AOVMutationsDbContext.cs
├── AOVMutationsBlazor.Shared/        # Gedeelde ViewModels
│   └── ViewModels/
│       └── MutationRequestViewModel.cs
└── AOVMutationsBlazor.Server/        # Blazor Server UI
    ├── Components/
    │   ├── Layout/
    │   ├── Pages/
    │   │   ├── Home.razor
    │   │   ├── MutationWizard.razor
    │   │   ├── Mutations.razor
    │   │   └── components/
    │   │       ├── PersonSection.razor
    │   │       ├── AddressSection.razor
    │   │       └── EmploymentSection.razor
    │   └── App.razor
    └── Program.cs
```

## Functionaliteiten

- **Inschrijving**: Nieuwe werknemers aanmelden
- **Wijziging**: Wijziging van werknemersgegevens  
- **Afmelding**: Werknemers afmelden
- **Persoonsgegevens**: BSN, naam, geboortedatum, contactgegevens
- **Adresgegevens**: Straat, postcode, plaats conform Nederlands formaat
- **Dienstverband**: Contract details, salaris, werkuren, SZV-PRIS codes

## Technologieën

- **.NET 9.0**: Framework
- **Blazor Server**: Interactive server-side rendering
- **Entity Framework Core 9.0**: Database ORM
- **MudBlazor 8.15.0**: Material Design component library
- **SQL Server**: Database (met InMemory fallback voor development)

## Database Schema (SZV-PRIS)

### MutationRequests
- Aanvraag metadata (nummer, datum, type, status)
- Foreign keys naar Person, Address, Employment

### Persons
- BSN (Burgerservicenummer)
- Naam en initialen
- Geboortedatum en -plaats
- Nationaliteit
- Contactgegevens

### Addresses
- Nederlandse adresformaat
- Postcode validatie
- Ondersteuning voor meerdere landen

### Employments
- Contract details
- Salaris en werkuren
- SZV-PRIS specifieke velden (inkomstencode, sectorcode)
- AOV verzekeringsstatus

## Setup

### Vereisten
- .NET 9.0 SDK of hoger
- SQL Server (optioneel, gebruikt InMemory database als SQL Server niet beschikbaar is)

### Installatie

1. **Clone de repository**
```bash
git clone https://github.com/alejandroriverovaldescaro/AOVMutationsBlazor.git
cd AOVMutationsBlazor
```

2. **Restore packages**
```bash
dotnet restore
```

3. **Build de solution**
```bash
dotnet build
```

4. **Run de applicatie**
```bash
cd AOVMutationsBlazor.Server
dotnet run
```

De applicatie is beschikbaar op `https://localhost:7xxx` of `http://localhost:5xxx` (poort kan variëren).

### Database Configuratie

#### SQL Server
Update `appsettings.json` met je connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YourServer;Database=AOVMutationsDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

#### InMemory Database (Development)
De applicatie gebruikt automatisch een InMemory database als de SQL Server connection niet beschikbaar is.

### Database Migrations (optioneel)

```bash
cd AOVMutationsBlazor.Data
dotnet ef migrations add InitialCreate --startup-project ../AOVMutationsBlazor.Server
dotnet ef database update --startup-project ../AOVMutationsBlazor.Server
```

## Gebruik

### Nieuwe Mutatie Aanmaken
1. Navigeer naar "Nieuwe Mutatie" in het menu
2. Selecteer het type mutatie (Inschrijving, Wijziging, of Afmelding)
3. Vul de persoonsgegevens in
4. Vul de adresgegevens in
5. Vul de dienstverbandgegevens in
6. Controleer het overzicht en sla op

### Mutaties Bekijken
- Klik op "Mutaties Overzicht" in het menu
- Bekijk alle aanvragen met status en type
- Filter en sorteer de resultaten

## Validatie

De applicatie bevat uitgebreide validatie:
- BSN moet 9 cijfers zijn
- Postcode moet Nederlands formaat volgen (1234AB)
- Email en telefoonnummer validatie
- Verplichte velden zijn gemarkeerd

## Ontwikkeling

### Code Structuur
- **Data Layer**: Entity Framework Core models en DbContext
- **Shared Layer**: ViewModels met data annotations voor validatie
- **UI Layer**: Blazor components met MudBlazor

### Styling
Het project gebruikt MudBlazor voor Material Design UI components met een paarse theme.

## Licentie

Dit is een starter kit project voor AOV mutatie aanvragen.

## Contact

Voor vragen of suggesties, open een issue in de GitHub repository.
