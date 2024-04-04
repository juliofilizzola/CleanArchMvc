using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public class Product {
    public int     Id          { get; private set; }
    public string  Name        { get; private set; }
    public string  Description { get; private set; }
    public decimal Price       { get; private set; }
    public int     Stock       { get; private set; }
    public string  Image       { get; private set; }
    public int     CategoryId  { get; private set; }
    public Category       Category           { get; private set; }

    public Product(string name, string description, string image, int stock, int categoryId) {
        ValidateDomain(name, description, stock, categoryId);
        Name        = name;
        Description = description;

    }

    private void ValidateDomain(string name, string description, int stock, int categoryId) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is Required");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description is Required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name.Name is Required");
        DomainExceptionValidation.When(description.Length < 3, "Invalid, Description is Required");
    }

}