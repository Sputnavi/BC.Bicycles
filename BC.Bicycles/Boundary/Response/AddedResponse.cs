using System.Net;

namespace BC.Bicycles.Boundary.Response;

public class AddedResponse : BaseResponseModel
{
    public Guid Id { get; set; }
    public AddedResponse(Guid id)
    {
        Id = id;
        StatusCode = HttpStatusCode.Created;
    }
}
