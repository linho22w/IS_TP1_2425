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
