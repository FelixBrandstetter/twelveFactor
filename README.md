# Twelve Factors Books App

 - Download Source Code
 - In das Directory, das das docker-compose file enthält, navigieren
 - Command Prompt öffnen und "docker-compose up" ausführen
	 - Docker Image wird automatisch gebuildet und die Container werden gestartet
 - mit "docker ps" alle gestarteten Docker Container anzeigen
	 - Port des twelvefactorbookapp Containers ablesen
 - Swagger API aufrufen durch: https://localhost:{port}/swagger
 - Folgende HTTP Requests werden unterstützt:
	 - GET: https://localhost:{port}/api/books:
		 - Gibt alle Bücher, die sich in der Datenbank befinden, zurück
	 - GET: https://localhost:{port}/api/books/{id}
		 - Gibt Buchdetails zu einer bestimmten id zurück
	 - POST: https://localhost:{port}/api/books
		 - Erstellt ein neues Buch mit folgendem HTTP-Body:
			 - ````json
				{
				  "isbn": "434327645745543654",
				  "title": "MyCoolBook",
				  "author": "Thomas Brezina",
				  "publisher": "MyVerlag"
				}
				````
	 - DELETE: https://localhost:{port}/api/Books/{id}
		 - Löst ein Buch mit einer bestimmten id