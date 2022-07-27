using System;
using MailKit.Net.Smtp;
using MimeKit;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services
{
    public class EmailService // Classe responsável pelo envio de email de confirmação de cadastro
    {
        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string codigoAtivacao)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, codigoAtivacao);

            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect("Conexao a fazer");

                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem) // Cria a mensagem de email
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("Adicionar o remetente"));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }
    }
        
}

