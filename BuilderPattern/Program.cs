using System;

// Product interface
public interface IInvoice
{
    void Generate();
}

// Concrete product for PDF invoice
public class PDFInvoice : IInvoice
{
    protected InvoiceDirector director;

    public PDFInvoice(InvoiceDirector director)
    { 
        this.director = director; 
    }

    public void Generate()
    {
        this.director.Construct();

        Console.WriteLine("Generating PDF Invoice");
    }
}

// Concrete product for Excel invoice
public class ExcelInvoice : IInvoice
{
    protected InvoiceDirector director;

    public ExcelInvoice(InvoiceDirector director)
    {
        this.director = director;
    }

    public void Generate()
    {
        this.director.Construct();

        Console.WriteLine("Generating Excel Invoice");
    }
}

// Builder interface
public interface IInvoiceBuilder
{
    void BuildHeader();
    void BuildBody();
    void BuildFooter();
}

// Concrete builder for PDF invoice
public class PDFInvoiceBuilder : IInvoiceBuilder
{
    public void BuildHeader()
    {
        Console.WriteLine("Building PDF Header");
    }

    public void BuildBody()
    {
        Console.WriteLine("Building PDF Body");
    }

    public void BuildFooter()
    {
        Console.WriteLine("Building PDF Footer");
    }
}

// Concrete builder for Excel invoice
public class ExcelInvoiceBuilder : IInvoiceBuilder
{
    public void BuildHeader()
    {
        Console.WriteLine("Building Excel Header");
    }

    public void BuildBody()
    {
        Console.WriteLine("Building Excel Body");
    }

    public void BuildFooter()
    {
        Console.WriteLine("Building Excel Footer");
    }
}

// Factory to create builders
public class InvoiceBuilderFactory
{
    public IInvoiceBuilder CreateInvoiceBuilder(string invoiceType)
    {
        switch (invoiceType)
        {
            case "PDF":
                return new PDFInvoiceBuilder();
            case "Excel":
                return new ExcelInvoiceBuilder();
            default:
                throw new ArgumentException("Invalid invoice type");
        }
    }
}

// Factory to create invoice
public class InvoiceFactory
{
    public IInvoice CreateInvoice(string invoiceType, InvoiceDirector director)
    {
        switch (invoiceType)
        {
            case "PDF":
                return new PDFInvoice(director);
            case "Excel":
                return new ExcelInvoice(director);
            default:
                throw new ArgumentException("Invalid invoice type");
        }
    }
}

// Director to control the building process
public class InvoiceDirector
{
    private IInvoiceBuilder _builder;

    public InvoiceDirector(IInvoiceBuilder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.BuildHeader();
        _builder.BuildBody();
        _builder.BuildFooter();
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // This could be dynamic based on user input
        string userRequest = "PDF"; 

        // Create builder using factory
        InvoiceBuilderFactory builderfactory = new InvoiceBuilderFactory();
        IInvoiceBuilder builder = builderfactory.CreateInvoiceBuilder(userRequest);

        // Use director to construct the invoice
        InvoiceDirector director = new InvoiceDirector(builder);

        // Create Invoice using factory
        InvoiceFactory factory = new InvoiceFactory();
        IInvoice invoice = factory.CreateInvoice(userRequest, director);

        // Get and generate the invoice
        invoice.Generate();
    }
}
