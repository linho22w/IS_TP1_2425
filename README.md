# Legacy Integration Bridge

Middleware and UI-automation solution that bridges an offline, legacy production-line system to a modern REST API, without changing a single line of the legacy system itself. Built for the Systems Integration course of my MSc in Computer Engineering at UTAD.

## 🎯 Context

An industrial company needs to move production data from a legacy desktop system on the shop floor into a web-based analytics system. The two systems don't talk to each other, so the transfer is manual, slow and error-prone. The goal is a reliable, near real-time integration layer between two heterogeneous systems, without touching the legacy application.

That last constraint is the interesting part: the legacy system can't be modified, so the data has to be captured the same way a human operator would read it, straight off the screen.

## 🧱 Architecture

```
 [Legacy source A]        [Legacy source B]
 SistemaProducaoDesktop    Consola_SistemaGeradorDados
 (WinForms, screen only)   (console output only)
        │                          │
        │ screen-click automation  │ OCR text capture
        ▼                          ▼
   SistemaLegado              (direct HTTP POST)
   (WinForms client)                │
        │                           │
        └────────────► ProducaoAPI ◄┘
                    (ASP.NET Core REST API)
                             │
                    SQL Server (stored procedures + triggers)
                    Producao DB ──trigger──► Contabilidade DB
```

- **SistemaProducaoDesktop**, a stand-in for the real legacy system: a WinForms app that generates random production records (part code, date, time, production time) and only ever displays them on screen. It has no network code at all, by design.
- **Consola_SistemaGeradorDados**, a second legacy-style data source: a console app that prints the same kind of production record as plain text, on a loop.
- **SistemaLegado**, a WinForms client that validates a production record and forwards it to the REST API over HTTP.
- **ProducaoAPI**, the ASP.NET Core Web API. Full CRUD for `Produto` and `Testes`, backed by SQL Server through stored procedures only (no inline SQL).
- **Database**, a `Producao` database (Produto, Testes) and a `Contabilidade` database (Custos_Peca). A trigger on `Produto` automatically calculates production cost, profit and loss per part whenever a new record is inserted, based on part type and test result.

## 🤖 Two automation strategies

Since the legacy system can't expose an API, [SikuliX](http://sikulix.com/) (image-recognition based UI automation) reads its screen instead. I built and compared two different approaches:

**`automation/screen-click-automation/`**, image-pattern based. Recognizes UI elements on screen by matching against reference images (`patterns/`), copies each field's value, and pastes it into `SistemaLegado`'s form before submitting. This mirrors exactly what a human operator does.

**`automation/ocr-text-capture/`**, OCR based. Selects a screen region over the console output, reads the text directly (SikuliX's built-in OCR), parses it, and posts straight to the REST API, skipping the intermediate form entirely.

The OCR approach turned out to be more robust: it doesn't depend on window position or exact pixel matches, only on the text being readable.

## 🗄️ Database

- `database/tables/`, schema for `Produto`, `Testes` and `Custos_Peca`.
- `database/stored-procedures/`, all data access from the API goes through these (insert, update, delete, select), never raw SQL from the controllers.
- `database/triggers/`, automatic cost/profit/loss calculation whenever a production or test record is inserted or changed, and automatic generation of a default test result when a part has none yet.

## 🛠️ Tech Stack

<p align="center">
  <img src="https://skillicons.dev/icons?i=cs,dotnet,py" />
</p>
<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge" />
  <img src="https://img.shields.io/badge/REST%20API-2496ED?style=for-the-badge" />
  <img src="https://img.shields.io/badge/SikuliX-000000?style=for-the-badge" />
  <img src="https://img.shields.io/badge/OCR-00897B?style=for-the-badge" />
  <img src="https://img.shields.io/badge/WinForms-37474F?style=for-the-badge" />
</p>

## 📂 Repository structure

```
src/
  IS_TP1.sln
  ProducaoAPI/                    ASP.NET Core REST API
  SistemaProducaoDesktop/         legacy production-line simulator (screen only)
  Consola_SistemaGeradorDados/    legacy console data source
  SistemaLegado/                  WinForms client that calls the API
database/
  tables/  stored-procedures/  triggers/
automation/
  screen-click-automation/        SikuliX, image-pattern based
  ocr-text-capture/                SikuliX, OCR based
```

## ▶️ Running it

This is a proof-of-concept built for a university assignment, not a deployable product, so running it end to end needs SQL Server, SikuliX and Visual Studio locally. In short:

1. Create the `Producao` and `Contabilidade` databases and run the scripts in `database/` (tables, then stored procedures, then triggers).
2. Update the connection string in `src/ProducaoAPI/Controllers/*.cs` to point at your local SQL Server instance.
3. Open `src/IS_TP1.sln` in Visual Studio and run `ProducaoAPI`, then `SistemaProducaoDesktop` or `Consola_SistemaGeradorDados`, then `SistemaLegado`.
4. Run one of the SikuliX scripts in `automation/` (needs the [SikuliX IDE](http://sikulix.com/)) to bridge the legacy source to the API.

## 👤 About

Part of my portfolio. See my [GitHub profile](https://github.com/linho22w) for more projects in AI/ML and backend development.
