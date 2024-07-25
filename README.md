
Factory Pattern: - It	is used to create instances of IInvoiceBuilder and IInvoice based on the type of invoice (PDF or Excel). The InvoiceBuilderFactory and InvoiceFactory classes implement this pattern.

Builder	Pattern:-  Separates the construction of a complex object (Invoice) from its representation. The IInvoiceBuilder interface and its concrete implementations (PDFInvoiceBuilder and ExcelInvoiceBuilder) encapsulate the construction of different parts of an invoice. The InvoiceDirector class orchestrates the construction process.

Dependency Injection:- 	The InvoiceDirector and IInvoice classes receive their dependencies (IInvoiceBuilder and InvoiceDirector, respectively) through their constructors, promoting loose coupling and flexibility.
