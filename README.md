# Paradigmi.Library
Progetto paradigmi di programmazione

Questo progetto è stato sviluppato come parte dell'esame di Paradigmi di Programmazione all'Università di Camerino. L'obiettivo del progetto è creare una Web API per la gestione del catalogo di una libreria, utilizzando tecnologie come ASP.NET Core e Entity Framework Core. Le principali funzionalità offerte dalla API sono:

- **Registrazione di un nuovo utente** (senza autenticazione iniziale)
- **Autenticazione utente**
- **Creazione di una nuova categoria** (non possono esistere due categorie con lo stesso nome)
- **Eliminazione di una categoria esistente** (solamente se la categoria non contiene libri)
- **Caricamento di un libro**
- **Modifica delle informazioni di un libro**
- **Eliminazione di un libro**
- **Ricerca di un libro** in base alle seguenti proprietà:
  - Categoria
  - Titolo del libro
  - Data di pubblicazione
  - Autore

# Avvio del progetto
Per avviare il progetto, seguire questi passaggi dopo aver scaricato il repository:

1. Ripristinare il database utilizzando il dump presente nel repository.
2. Modificare la stringa di connessione nel file `appsettings.json` situato all'interno del progetto `Paradigmi.Library.Web`.
3. Avviare il progetto.
4. Registrare un nuovo utente.
5. Effettuare il login con le credenziali appena create.
6. Inserire il token JWT generato al momento del login.

Una volta completati questi passaggi, sarà possibile accedere a tutte le funzionalità offerte dal progetto.
