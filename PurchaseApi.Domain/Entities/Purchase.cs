using PurchaseApi.Domain.Validations;

namespace PurchaseApi.Domain.Entities;

public class Purchase
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int PersonId { get; private set; }
    public DateTime Date { get; private set; }

    public Person Person { get; set; }
    public Product Product { get; set; }
    
    public Purchase(int productId, int personId)
    {
        Validation(productId, personId);
    }

    public Purchase(int id, int productId, int personId)
    { 
        DomainValidationException.When(Id < 0, "Id deve ser informado!");

        Id = id;
        Validation(productId, personId);
    }

    private void Validation(int productId, int personId)
    {
        DomainValidationException.When(productId < 0, "Product ID deve ser informado");
        DomainValidationException.When(personId < 0, "Person ID deve ser informado");

        ProductId = productId;
        PersonId = personId;
        Date = DateTime.Now;
    }
}