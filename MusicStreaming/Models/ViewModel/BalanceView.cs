using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.Models.ViewModel
{
    public class BalanceView
    {
        public decimal? Balance { get; set; } = 0;
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal? Amount { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Expiration { get; set; }
        [Required]
        public byte Cvv { get; set; }
        [Required]
        public string Name { get; set; }
        public string Result { get; set; } 
    }
}
