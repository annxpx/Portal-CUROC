﻿using Application.Contracts;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Mailers;

public class UserMailer(IEmailSender emailSender, IConfiguration configuration) : IUserMailer
{
    private const string FrontendtUrl = "Frontend:Url";
    private const string ConfirmAccountUrl = "UserMailer:ConfirmAccountUrl";
    private const string ResetPasswordUrl = "UserMailer:ResetPasswordUrl";
    private const string ActivityRequestedUrl = "UserMailer:ActivityRequestedUrl";
    
    public async Task SendConfirmationInstructionsAsync(
        string to,
        string token,
        CancellationToken cancellationToken = default
    )
    {
        const string subject = "Portal Curoc - Confirme su correo electrónico";
        var href = configuration[FrontendtUrl] + configuration[ConfirmAccountUrl]!.Replace("{0}", token);
        var html = $"""
                        <h1>Portal Curoc</h1>
                        <p>Por favor, confirme su correo electrónico haciendo clic en el siguiente enlace:</p>
                        <a href='{href}'>Confirmar correo electrónico</a>
                    """;

        await emailSender.SendEmailAsync(to, subject, html, cancellationToken);
    }


    public async Task SendForgotPasswordInstructionsAsync(
        string to,
        string token,
        CancellationToken cancellationToken = default
    )
    {
        const string subject = "Portal Curoc - Restablezca su contraseña";
        var href = configuration[FrontendtUrl] + configuration[ResetPasswordUrl]!.Replace("{0}", token);
        var html = $"""
                        <h1>Portal Curoc</h1>
                        <p>Por favor, restablezca su contraseña haciendo clic en el siguiente enlace:</p>
                        <a href='{href}/reset-password?token={token}'>Restablecer contraseña</a>
                    """;

        await emailSender.SendEmailAsync(to, subject, html, cancellationToken);
    }

    public async Task SendResetPasswordConfirmationAsync(
        string to,
        CancellationToken cancellationToken = default
    )
    {
        const string subject = "Portal Curoc - Su contraseña ha sido restablecida";
        const string html = """
                                <h1>Portal Curoc</h1>
                                <p>Su contraseña ha sido restablecida exitosamente.
                                Si usted no realizó esta solicitud, por favor contacte con nuestro soporte.
                                </p>
                            """;

        await emailSender.SendEmailAsync(to, subject, html, cancellationToken);
    }

    public async Task SendWelcomeEmailAsync(string to, CancellationToken cancellationToken = default)
    {
        const string subject = "Bienvenido a Portal Curoc";
        var href = configuration[FrontendtUrl]!;
        var html = $"""
                        <h1>Bienvenido a Portal CUROC</h1>
                        <p>Gracias por registrarte. Estamos encantados de tenerte con nosotros.</p>
                        <p>Explora nuestras funciones y servicios en el siguiente enlace:</p>
                        <a href='{href}'>Ir a Portal CUROC</a>
                    """;

        await emailSender.SendEmailAsync(to, subject, html, cancellationToken);
    }

    public async Task SendActivityRequestedAsync(string to, string activitySlug,
        CancellationToken cancellationToken = default)
    {
        const string subject = "Nueva Actividad en Portal CUROC";
        var href = configuration[FrontendtUrl] + configuration[ActivityRequestedUrl]!.Replace("{0}", activitySlug);
        var html = $"""
                        <h1>Se ha solicitado una nueva actividad</h1>
                        <p>Hay una nueva actividad disponible para ti. Puedes verla en el siguiente enlace:</p>
                        <a href='{href}'>Ver Actividad</a>
                    """;

        await emailSender.SendEmailAsync(to, subject, html, cancellationToken);
    }

    public async Task SendActivityConfirmationAsync(
    string to,
    string token,
    Activity activity,  // Nuevo parámetro para la actividad
    CancellationToken cancellationToken = default
)
{
    const string subject = "Portal Curoc - Confirme la actividad: {0}";
    var href = configuration[FrontendtUrl] + configuration[ConfirmActivityUrl]!.Replace("{0}", token);
    
    var html = $"""
                    <h1>Portal Curoc</h1>
                    <p>Por favor, confirme la siguiente actividad:</p>
                    <h2>{activity.Name}</h2>
                    <p>{activity.Description}</p>
                    <p><strong>Fecha:</strong> {activity.StartDate:dd/MM/yyyy} - {activity.EndDate:dd/MM/yyyy}</p>
                    <p><strong>Organizador:</strong> {activity.OrganizerName}</p>
                    <a href='{href}'>Confirmar Actividad</a>
                """;

    await emailSender.SendEmailAsync(to, string.Format(subject, activity.Name), html, cancellationToken);
}

    public async Task SendApproveActivityAsync(
    string to,
    string token,
    Activity activity,  // Parámetro para la actividad
    CancellationToken cancellationToken = default
)
{
    const string subject = "Portal Curoc - Respuesta de solicitud: {0}";
    var href = configuration[FrontendtUrl] + configuration[ConfirmActivityUrl]!.Replace("{0}", token);
    
    var html = $"""
                    <h1>Portal Curoc</h1>
                    <p>Su actividad solicitada ha sido aprobada</p>
                    <h2>{activity.Name}</h2>
                    <p>{activity.Description}</p>
                    <p><strong>Fecha:</strong> {activity.StartDate:dd/MM/yyyy} - {activity.EndDate:dd/MM/yyyy}</p>
                    <p><strong>Organizador:</strong> {activity.OrganizerName}</p>
                    <a href='{href}'>Confirmar Actividad</a>
                """;

    await emailSender.SendEmailAsync(to, string.Format(subject, activity.Name), html, cancellationToken);
}

    public async Task SendRejectActivityAsync(
    string to,
    Activity activity,  // Parámetro para la actividad
    string rejectionReason,  // Razón del rechazo
    CancellationToken cancellationToken = default
)
{
    const string subject = "Portal Curoc - Actividad Rechazada: {0}";
    
    var html = $"""
                    <h1>Portal Curoc</h1>
                    <p>Lamentamos informarle que la siguiente actividad ha sido rechazada:</p>
                    <h2>{activity.Name}</h2>
                    <p>{activity.Description}</p>
                    <p><strong>Fecha:</strong> {activity.StartDate:dd/MM/yyyy} - {activity.EndDate:dd/MM/yyyy}</p>
                    <p><strong>Organizador:</strong> {activity.OrganizerName}</p>
                    <p><strong>Razón del rechazo:</strong> {rejectionReason}</p>
                    <p>Si tiene alguna pregunta o desea discutir este rechazo, por favor, presentese en las oficinas de VOAE.</p>
                """;

    await emailSender.SendEmailAsync(to, string.Format(subject, activity.Name), html, cancellationToken);
}
}