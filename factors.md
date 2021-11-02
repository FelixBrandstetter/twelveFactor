1. Codebase
Eine gemeinsame Codebase pro App, in unserem Fall ein GitHub Repository

2. Dependencies
Die von der App benötigten Abhängigkeiten werden im Dockerfile und im docker-compose.yml festgelegt (z.B. Abhängigkeiten zum .NET Paket sowie MS SQL Paket)

3. Configuration
Die Konfiguration der App geschieht im appsettings.json File. Hier können Datenbankconnection sowie Logging konfiguriert werden

4. Backing services
???

5. Build, release, run
???

6. Processes
Die App läuft als separater und abgekapselter Prozess als Docker Container und existiert dadurch unabhängig von anderen Prozessen

7. Port Binding
Die App wird durch einen speziellen Port dem Benutzer zur Verfügung gestellt
Die ASP .NET Api kann durch den Einsatz von Kestrel die App zur Verfügung stellen

8. Concurrency
Durch die REST Web Api wird ein "stateless" Prozes sichergestellt
Requests werden asynchron abgearbeitet
Es können mehrere Requests in sehr kurzen Intervallen geschickt werden, die alle von der Web Api abgearbeitet werden

10. Disposability
??? CancellationToken

11. Dev/Prod parity
???

12. Logs
Durch den Einsatz von Serilog werden Log-Einträge auf stdout geschrieben
ILogger wird in die jeweiligen Klassen injected

13. Admin Processes
???