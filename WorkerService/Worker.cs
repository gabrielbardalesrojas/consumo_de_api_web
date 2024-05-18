using WorkerService.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.Models;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly CursoService _cursoService;
        private readonly EmailService _emailService;

        public Worker(ILogger<Worker> logger, CursoService cursoService, EmailService emailService)
        {
            _logger = logger;
            _cursoService = cursoService;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var cursos = await _cursoService.GetCursosAsync();
                var cursoSaludo = cursos.FirstOrDefault(); // Elige el primer curso para el saludo

                if (cursoSaludo != null)
                {
                    string subject = "Saludos del Curso";
                    string body = $"Hola, el curso {cursoSaludo.Nombre} es impartido por el profesor {cursoSaludo.Profesor} en el ciclo {cursoSaludo.Ciclo}.";

                    // Reemplaza con el correo electrónico del destinatario
                    string to = "rolando.bardales@unas.edu.pe";

                    await _emailService.SendEmailAsync(to, subject, body);
                    _logger.LogInformation("Correo enviado a {to} con asunto {subject}", to, subject);
                }

                await Task.Delay(60000, stoppingToken); // Espera 1 minuto antes de ejecutar de nuevo
            }
        }
    }
}
