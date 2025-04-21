namespace SaM.Core.Middlewares;

public static class ProblemTypeUris
{
    public const string BadRequest = "https://tools.ietf.org/html/rfc7231#section-6.5.1";          // 400
    public const string Unauthorized = "https://tools.ietf.org/html/rfc7235#section-3.1";           // 401
    public const string Forbidden = "https://tools.ietf.org/html/rfc7231#section-6.5.3";            // 403
    public const string NotFound = "https://tools.ietf.org/html/rfc7231#section-6.5.4";             // 404
    public const string MethodNotAllowed = "https://tools.ietf.org/html/rfc7231#section-6.5.5";     // 405
    public const string Conflict = "https://tools.ietf.org/html/rfc7231#section-6.5.8";             // 409
    public const string UnsupportedMediaType = "https://tools.ietf.org/html/rfc7231#section-6.5.13";// 415
    public const string UnprocessableEntity = "https://tools.ietf.org/html/rfc4918#section-11.2";   // 422 (WebDAV)
    public const string InternalServerError = "https://tools.ietf.org/html/rfc7231#section-6.6.1";  // 500
    public const string NotImplemented = "https://tools.ietf.org/html/rfc7231#section-6.6.2";       // 501
    public const string BadGateway = "https://tools.ietf.org/html/rfc7231#section-6.6.3";           // 502
    public const string ServiceUnavailable = "https://tools.ietf.org/html/rfc7231#section-6.6.4";   // 503
}