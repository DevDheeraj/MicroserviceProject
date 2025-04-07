﻿using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<ActionResult> SendNotification([FromBody] string message)
        {
            await _notificationService.SendNotification(message);
            return Ok("Notification Sent!");
        }
    }
}
