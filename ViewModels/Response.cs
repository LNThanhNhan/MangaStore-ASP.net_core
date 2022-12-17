﻿namespace MangaStore.ViewModels;

[Serializable]
public class Response
{
    public bool success { get; set; }
    public string message { get; set; }=string.Empty;
    public object data { get; set; }=null;
}
