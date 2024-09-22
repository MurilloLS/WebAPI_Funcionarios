using System.Text.Json.Serialization;

namespace WebAPI_Funcionarios.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
      Manha,
      Tarde,
      Noite
    }
}
