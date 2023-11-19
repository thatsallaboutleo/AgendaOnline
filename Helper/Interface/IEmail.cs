namespace AgendaOnline.Helper.Interface
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string msg);
    }
}
