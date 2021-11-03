### 1. Codebase
Eine gemeinsame Codebase pro App, in unserem Fall ein GitHub Repository (https://github.com/FelixBrandstetter/twelveFactor)

### 2. Dependencies
Die von der App benötigten Abhängigkeiten werden im Dockerfile und im docker-compose.yml festgelegt (z.B. Abhängigkeiten zum .NET Paket sowie MS SQL Paket)
NuGet-Dependencies sind im Projekt File (.csproj) deklariert

### 3. Configuration
Die Konfiguration der App geschieht im appsettings.json File. Hier können Datenbankconnection sowie Logging konfiguriert werden. Diese könnte auch noch von außen überschrieben werden (dazu müsste im program.cs nur eine Zeile hinzugefügt werden).

### 6. Processes
Die App läuft als separater und abgekapselter Prozess als Docker Container und existiert dadurch unabhängig von anderen Prozessen des Hosts.

### 7. Port Binding
Die App wird durch einen speziellen Port dem Benutzer zur Verfügung gestellt.
Die ASP .NET Api stellt durch den Einsatz von Kestrel die App zur Verfügung.

### 8. Concurrency
Durch die REST Web Api wird ein "stateless" Prozes sichergestellt
Requests werden asynchron abgearbeitet
Es können mehrere Requests in sehr kurzen Intervallen geschickt werden, die alle von der Web Api abgearbeitet werden

### 11. Dev/Prod parity
Dev und Prod verhalten sich aufgrund der geringen Komplexität ähnlich/gleich.

### 12. Logs
Durch den Einsatz von Microsoft-Logging werden Log-Einträge auf stdout geschrieben
ILogger wird in die jeweiligen Klassen injected und kann dort verwendet werden
