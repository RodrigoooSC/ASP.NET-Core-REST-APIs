using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace UsuarioAPI.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; } // Tipo especial que identifica um endereço de email
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Destinatario = new List<MailboxAddress>(); // Instancia uma lista de MailboxAddress
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d))); // Adiciona uma string de destinatario a nossa lista de email
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/ativa?UsuarioId={usuarioId}&COdigoDeAtivacao={codigo}";
        }
        
        
        
        
        
        
    }
}