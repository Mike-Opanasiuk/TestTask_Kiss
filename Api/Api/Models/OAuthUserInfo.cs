﻿namespace Api.Models;

public class OAuthUserInfo
{
    public string Id { get; set; }
    public string Email { get; set; }
    public bool IsVerifiedUser { get; set; }
    public string Picture { get; set; }
    //    {
    //    "id": "106633207726754330371",
    //    "email": "iiwooltrapii@gmail.com",
    //    "verified_email": true,
    //    "picture": "https://lh3.googleusercontent.com/a-/ALV-UjUS_eCkbm7N6ohfER8U5byfORmasWKmetM3EALlR2WsZCU=s96-c"
    //}
}
