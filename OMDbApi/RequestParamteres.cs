using OMDbApi.Model;

namespace OMDbApi
{
    public struct RequestParamteres
    {
        public string ImdbId;
        public string Title;
        public int? Page;
        public ResponseTypes ResponseType;
        public string Version;
    }
}
