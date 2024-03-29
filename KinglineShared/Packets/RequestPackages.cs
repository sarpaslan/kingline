﻿using System;
using System.Collections.Generic;
using System.Text;

public class ReqInventory { }
public class ReqMineStone { }
public class ReqMineBone { }
public class ReqPlayerXp { }
public class ReqPlayers { }
public class ReqPlayerTeam { }
public class ReqPlayerMove
{
    public float x { get; set; }
    public float y { get; set; }
}
public class ReqStructures
{
}

public class ReqPlayerProgression
{
}
public class ReqUpgradeTeam
{
    public int MemberId { get; set; }
}

public class ReqSkillIncrement
{
    public string SkillName { get; set; }
}

public class ReqSellItem
{
    public int Index { get; set; }
    public short Count { get; set; }
}

public class ReqVolunteers
{
    public int StructureId { get; set; }
}
public class ReqBuyVolunteers
{
    public int StructureId { get; set; }
    public int Id { get; set; }
    public short Count { get; set; }
}

public class ReqAdminPrivileges
{
    public string Password { get; set; }
}
public class ReqRemoteCommand
{
    public string Command { get; set; }
    public string[] Arguments { get; set; }
}


public class ReqStructureInventory
{
    public int StructureId { get; set; }
}
