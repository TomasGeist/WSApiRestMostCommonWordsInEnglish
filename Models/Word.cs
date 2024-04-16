using System;
using System.Collections.Generic;
namespace WSmostCommonWordsInEnglishNuevo.Models;

public partial class Word
{
    public int IdWord { get; set; }

    public string? EnglishWord { get; set; }

    public string? TranslatedWord { get; set; }

    public string? Example { get; set; }
}
