/**
 * ______________________________________________________
 * This file is part of ko-packet-logger project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable All

namespace KOPacketTool.Class
{
    enum OPAuthCharSelection
    {
        WIZ_LOGIN = 0x01,
        WIZ_NEW_CHAR = 0x02,
        WIZ_DEL_CHAR = 0x03,
        WIZ_SEL_CHAR = 0x04,
        WIZ_SEL_NATION = 0x05,
        WIZ_ALLCHAR_INFO_REQ = 0x0C,
        WIZ_VERSION_CHECK = 0x2B,
        WIZ_CRYPTION = 0x2C,
    }

    enum OPPlayerInformation
    {
        WIZ_MYINFO = 0x0E,
        WIZ_LOGOUT = 0x0F,
        WIZ_SKILLDATA = 0x79,
        WIZ_PREMIUM = 0x71,
    }

    enum OPMovementRegion
    {
        WIZ_MOVE = 0x06,
        WIZ_ROTATE = 0x09,
        WIZ_USER_INOUT = 0x07,

        WIZ_NPC_INOUT = 0x0A,
        WIZ_NPC_MOVE = 0x0B,
        WIZ_REGIONCHANGE = 0x15,
        WIZ_REQ_USERIN = 0x16,
        WIZ_NPC_REGION = 0x1C,
        WIZ_REQ_NPCIN = 0x1D,
        WIZ_MERCHANT_INOUT = 0x69,
    }


    enum OPPlayerState
    {
        WIZ_DEAD = 0x11,
        WIZ_CORPSE = 0x4E,
        WIZ_REGENE = 0x12,
        WIZ_ATTACK = 0x08,
        WIZ_HP_CHANGE = 0x17,
        WIZ_MSP_CHANGE = 0x18,
        WIZ_EXP_CHANGE = 0x1A,
        WIZ_LEVEL_CHANGE = 0x1B,
        WIZ_TARGET_HP = 0x22,
        WIZ_WARP = 0x1E,
        WIZ_ZONE_CHANGE = 0x27,
        WIZ_POINT_CHANGE = 0x28,
        WIZ_STATE_CHANGE = 0x29,
        WIZ_LOYALTY_CHANGE = 0x2A,
        WIZ_USERLOOK_CHANGE = 0x2D,
        WIZ_SKILLPT_CHANGE = 0x32,
        WIZ_CLASS_CHANGE = 0x34,
        WIZ_HOME = 0x48,
        WIZ_GOLD_CHANGE = 0x4A,
        WIZ_KICKOUT = 0x51,
        WIZ_WEIGHT_CHANGE = 0x54,
        WIZ_AUTHORITY_CHANGE = 0x58,// Authority change 
        WIZ_STEALTH = 0x60,// stealth related.
        WIZ_KISS = 0x66,
        WIZ_NAME_CHANGE = 0x6E,
        WIZ_CAPE = 0x70,

        WIZ_CHALLENGE = 0x75,
        WIZ_HELMET = 0x87,
        WIZ_CHAT_TARGET = 0x35,
        WIZ_CHANGE_HAIR = 0x89, // Changes hair colour/facial features at character selection
        WIZ_PVP = 0x88, // rivalry
        WIZ_TIMENOTIFY = 0x39,
        WIZ_RECOMMEND_USER = 0x67,
    }

    enum OPGameState
    {
        WIZ_GAMESTART = 0x0D,
        WIZ_TIME = 0x13,
        WIZ_WEATHER = 0x14,
        WIZ_NOTICE = 0x2E,
        WIZ_DATASAVE = 0x37,
        WIZ_SPEEDHACK_CHECK = 0x41,
        WIZ_SERVER_CHECK = 0x43,
        WIZ_SERVER_CHANGE = 0x46,
        WIZ_REPORT_BUG = 0x47,
        WIZ_WARP_LIST = 0x4B,
        WIZ_VIRTUAL_SERVER = 0x4C,
        WIZ_ZONE_CONCURRENT = 0x4D,
        WIZ_WAR_SYSTEM = 0x53,
        WIZ_BATTLE_EVENT = 0x57,    // Battle Event Result
        WIZ_SANTA = 0x5A,// Activate motherfucking Santa Claus!!! :(
        WIZ_ZONEABILITY = 0x5E,
        WIZ_EVENT = 0x5F,
        WIZ_ROOM_PACKETPROCESS = 0x61, // room system
        WIZ_ROOM = 0x62,
        WIZ_SERVER_INDEX = 0x6B,
        WIZ_HACKTOOL = 0x72,
        WIZ_RANK = 0x80,
        WIZ_STORY = 0x81,
        WIZ_LOGOSSHOUT = 0x7D,
        WIZ_PROGRAMCHECK = 0x7A,
        WIZ_CHINA = 0x77,// we shouldn't need to worry about this
        WIZ_WEBPAGE = 0x6F,
        WIZ_BIFROST = 0x7B,
        WIZ_EFFECT = 0x6C,
        WIZ_DEATH_LIST = 0x90,
        WIZ_CLANPOINTS_BATTLE = 0x91,// not sure
        WIZ_CONCURRENTUSER = 0x36,
        WIZ_KNIGHTS_LIST = 0x3E,
        WIZ_PPCARD_CHINA = 0x65,
        WIZ_TEST_PACKET = 0xff, // Test packet
    }

    enum OPProtocol
    {
        WIZ_COMPRESS_PACKET = 0x42,
        WIZ_CONTINOUS_PACKET = 0x44,
    }

    enum OPSystems
    {

        WIZ_CHAT = 0x10,    /* and subopcodes */
        WIZ_CHATROOM = 0x19,
        WIZ_PARTY = 0x2F,
        WIZ_EXCHANGE = 0x30,
        WIZ_MAGIC_PROCESS = 0x31,
        WIZ_OPERATOR = 0x40,
        WIZ_KNIGHTS_PROCESS = 0x3C,
        WIZ_WAREHOUSE = 0x45,
        WIZ_FRIEND_PROCESS = 0x49,
        WIZ_PARTY_BBS = 0x4F,
        WIZ_MARKET_BBS = 0x50,
        WIZ_QUEST = 0x64,
        WIZ_KING = 0x78,
        WIZ_SIEGE = 0x6D,
        WIZ_REPORT = 0x7C,
        WIZ_SHOPPING_MALL = 0x6A,
        WIZ_PET = 0x76,
        WIZ_RENTAL = 0x73,
        WIZ_MINING = 0x86,
        WIZ_WATCHMAN = 0xCC,
    }

    enum OPItemRelated
    {
        WIZ_ITEM_MOVE = 0x1F,
        WIZ_ITEM_TRADE = 0x21,
        WIZ_ITEM_DROP = 0x23,
        WIZ_BUNDLE_OPEN_REQ = 0x24,
        WIZ_ITEM_GET = 0x26,
        WIZ_DURATION = 0x38,
        WIZ_ITEM_REPAIR = 0x3B,
        WIZ_ITEM_COUNT_CHANGE = 0x3D,
        WIZ_ITEM_REMOVE = 0x3F,
        WIZ_ITEM_UPGRADE = 0x5B,
    }

    enum OPNPCInteraction
    {
        WIZ_NPC_EVENT = 0x20,
        WIZ_TRADE_NPC = 0x25,
        WIZ_OBJECT_EVENT = 0x33,
        WIZ_REPAIR_NPC = 0x3A,
        WIZ_CLIENT_EVENT = 0x52,
        WIZ_SELECT_MSG = 0x55,
        WIZ_NPC_SAY = 0x56,// Select Event Message...
        WIZ_EDIT_BOX = 0x59,// Act
    }


    ////////////////////////////////////////////////////////////////
    // chat define
    ////////////////////////////////////////////////////////////////
    enum ChatType
    {
        GENERAL_CHAT = 1,
        PRIVATE_CHAT = 2,
        PARTY_CHAT = 3,
        FORCE_CHAT = 4,
        SHOUT_CHAT = 5,
        KNIGHTS_CHAT = 6,
        PUBLIC_CHAT = 7,
        WAR_SYSTEM_CHAT = 8,
        PERMANENT_CHAT = 9,
        END_PERMANENT_CHAT = 10,
        QUEST_ERROR_CHAT = 11,  // Quest failed (red text, middle of screen)
        GM_CHAT = 12,
        COMMAND_CHAT = 13,
        MERCHANT_CHAT = 14,
        ALLIANCE_CHAT = 15,
        GREEN_CHAT = 16,
        ANNOUNCEMENT_CHAT = 17,
        SEEKING_PARTY_CHAT = 19,
        GM_INFO_CHAT = 21,  // info window : "Level: 0, UserCount:16649" (NOTE: Think this is the missing overhead info (probably in form of a command (with args))
        COMMAND_PM_CHAT = 22,   // Commander Chat PM??
        CLAN_NOTICE = 24,
        KROWAZ_NOTICE = 25,
        DEATH_NOTICE = 26,
        CHAOS_STONE_NOTICE = 27,    // The enemy has destroyed the Chaos stone something (Red text, middle of screen)
        ANNOUNCEMENT_WHITE_CHAT = 29    // what's it used for?
    };

    enum TradeOpcodes
    {
        EXCHANGE_REQ = 1,
        EXCHANGE_AGREE = 2,
        EXCHANGE_ADD = 3,
        EXCHANGE_OTHERADD = 4,
        EXCHANGE_DECIDE = 5,
        EXCHANGE_OTHERDECIDE = 6,
        EXCHANGE_DONE = 7,
        EXCHANGE_CANCEL = 8,
        EXCHANGE_DUPLICATE = 9
    };

    enum MerchantOpcodes
    {
        MERCHANT_OPEN = 1,
        MERCHANT_CLOSE = 2,
        MERCHANT_ITEM_ADD = 3,
        MERCHANT_ITEM_CANCEL = 4,
        MERCHANT_ITEM_LIST = 5,
        MERCHANT_ITEM_BUY = 6,
        MERCHANT_INSERT = 7,
        MERCHANT_TRADE_CANCEL = 8,
        MERCHANT_ITEM_PURCHASED = 9,

        MERCHANT_BUY_OPEN = 0x21,
        MERCHANT_BUY_INSERT = 0x22,
        MERCHANT_BUY_LIST = 0x23,
        MERCHANT_BUY_BUY = 0x24,
        MERCHANT_BUY_SOLD = 0x25,
        MERCHANT_BUY_BOUGHT = 0x26,
        MERCHANT_BUY_CLOSE = 0x27,
        MERCHANT_BUY_REGION_INSERT = 0x28,
        MERCHANT_BUY_UNK1 = 0x30
    };

    enum MiningSystemOpcodes
    {
        // Starts the mining process
        MiningStart = 1,

        // Every n seconds, calls this packet to see if they found anything.
        MiningAttempt = 2,

        // Stops the mining process
        MiningStop = 3,

        // Soccer handler is part of the mining handler (yuck).
        MiningSoccer = 16,
    };

    enum MagicOpcode
    {
        MAGIC_CASTING = 1,
        MAGIC_FLYING = 2,
        MAGIC_EFFECTING = 3,
        MAGIC_FAIL = 4,
        MAGIC_DURATION_EXPIRED = 5, // For the removal of durational (i.e. type 3/4) skills.
        MAGIC_CANCEL = 6,   // When the client requests a buff to be removed.
        MAGIC_CANCEL_TRANSFORMATION = 7,    // When removing a transformation.
        MAGIC_TYPE4_EXTEND = 8, // Extends the time of your type4 buffs by 2 times (requires "Duration Item" (PUS))
        MAGIC_TRANSFORM_LIST = 9,   // Shows the transformation list 
        MAGIC_FAIL_TRANSFORMATION = 10, // Transformation errors
        MAGIC_UNKNOWN = 12,
        MAGIC_CANCEL2 = 13  // Not sure but it cancels...
    };

    enum Knights
    {
        KNIGHTS_CREATE = 0x01, // clan creation
        KNIGHTS_JOIN = 0x02, // joining a clan
        KNIGHTS_WITHDRAW = 0x03, // leaving a clan
        KNIGHTS_REMOVE = 0x04,  // removing a clan member
        KNIGHTS_DESTROY = 0x05, // disbanding a clan
        KNIGHTS_ADMIT = 0x06,
        KNIGHTS_REJECT = 0x07,
        KNIGHTS_PUNISH = 0x08,
        KNIGHTS_CHIEF = 0x09,
        KNIGHTS_VICECHIEF = 0x0A,
        KNIGHTS_OFFICER = 0x0B,
        KNIGHTS_ALLLIST_REQ = 0x0C,
        KNIGHTS_MEMBER_REQ = 0x0D,
        KNIGHTS_CURRENT_REQ = 0x0E,
        KNIGHTS_STASH = 0x0F,
        KNIGHTS_MODIFY_FAME = 0x10,
        KNIGHTS_JOIN_REQ = 0x11,
        KNIGHTS_LIST_REQ = 0x12,

        KNIGHTS_WAR_ANSWER = 0x14,
        KNIGHTS_WAR_SURRENDER = 0x15,

        KNIGHTS_MARK_VERSION_REQ = 0x19,
        KNIGHTS_MARK_REGISTER = 0x1A,
        KNIGHTS_CAPE_NPC = 0x1B,
        KNIGHTS_ALLY_CREATE = 0x1C,
        KNIGHTS_ALLY_REQ = 0x1D,
        KNIGHTS_ALLY_INSERT = 0x1E,
        KNIGHTS_ALLY_REMOVE = 0x1F,
        KNIGHTS_ALLY_PUNISH = 0x20,
        KNIGHTS_ALLY_LIST = 0x22,

        KNIGHTS_MARK_REQ = 0x23,
        KNIGHTS_UPDATE = 0x24,
        KNIGHTS_MARK_REGION_REQ = 0x25,
        KNIGHTS_USER_ONLINE_NOTIFY = 0x27,
        KNIGHTS_USER_OFFLINE_NOTIFY = 0x28,

        KNIGHTS_UPDATE_GRADE = 0x30,
        KNIGHTS_POINT_REQ = 0x3B,
        KNIGHTS_DONATE_POINTS = 0x3D,
        KNIGHTS_HANDOVER_REQ = 0x3E,
        KNIGHTS_HANDOVER_CONFIRM = 0x3F,

        KNIGHTS_DONATION_LIST = 0x40,
        KNIGHTS_TOP10 = 0x41,

        // These are NOT official client opcodes.
        // They are opcodes for the database thread only.
        KNIGHTS_REFUND_POINTS = 0xF0,
        KNIGHTS_UPDATE_FUND = 0xF1
    };

    enum OperatorCommands
    {
        OPERATOR_ARREST = 1,
        OPERATOR_BAN = 2,
        OPERATOR_MUTE = 3,
        OPERATOR_UNMUTE = 4,
        OPERATOR_CUTOFF = 5,
        OPERATOR_BAN_ACCOUNT = 6,
        OPERATOR_SUMMON = 7,
        OPERATOR_DISABLE_ATTACK = 8,
        OPERATOR_ENABLE_ATTACK = 9
    };

    enum FriendOpcodes
    {
        FRIEND_REQUEST = 1,
        FRIEND_REPORT = 2,
        FRIEND_ADD = 3,
        FRIEND_REMOVE = 4
    };

    enum ItemUpgradeOpcodes
{
        ITEM_UPGRADE_REQ = 1,
        ITEM_UPGRADE = 2,
        ITEM_ACCESSORIES = 3,
        ITEM_BIFROST_REQ = 4,
        ITEM_BIFROST_EXCHANGE = 5,
        ITEM_UPGRADE_REBIRTH = 7,
        ITEM_SEAL = 8,
        ITEM_CHARACTER_SEAL = 9
    };

    enum ShoppingMallOpcodes
    {
        STORE_OPEN = 1,
        STORE_CLOSE = 2,
        STORE_BUY = 3,
        STORE_MINI = 4,
        STORE_PROCESS = 5,
        STORE_LETTER = 6
    };

    enum LetterOpcodes
    {
        LETTER_UNREAD = 1,
        LETTER_LIST = 2,
        LETTER_HISTORY = 3,
        LETTER_GET_ITEM = 4,
        LETTER_READ = 5,
        LETTER_SEND = 6,
        LETTER_DELETE = 7,
        LETTER_ITEM_CHECK = 8 // ???
    };

    enum SkillBarOpcodes
    {
        SKILL_DATA_SAVE = 1,
        SKILL_DATA_LOAD = 2
    };

    enum RentalOpcodes
    {
        RENTAL_PREMIUM = 1,
        RENTAL_PVP = 2,
        RENTAL_NPC = 3
    };
    enum RentalPvPOpcodes
    {
        RENTAL_OPEN = 0,
        RENTAL_REGISTER = 1,
        RENTAL_LEND = 2,
        RENTAL_ITEM_CHECK = 3,
        RENTAL_ITEM_CANCEL = 4,
        RENTAL_REPORT = 10
    };

    enum PartyBBSOpcodes
    {
        PARTY_BBS_REGISTER = 0x01,
        PARTY_BBS_DELETE = 0x02,
        PARTY_BBS_NEEDED = 0x03,
        PARTY_BBS_WANTED = 0x04,
        PARTY_BBS_JOIN_REQ = 0x08,
        PARTY_BBS_JOIN_REJECT = 0x09,
        PARTY_BBS_JOIN_ACCEPT = 0x0A,
        PARTY_BBS_LIST = 0x0B,
    }

    enum WarehouseOpcodes
    {
        WAREHOUSE_OPEN = 0x01,
        WAREHOUSE_INPUT = 0x02,
        WAREHOUSE_OUTPUT = 0x03,
        WAREHOUSE_MOVE = 0x04,
        WAREHOUSE_INVENMOVE = 0x05,
        WAREHOUSE_PASSWORD = 0x06,

        WAREHOUSE_REQ = 0x10
    }

    enum WeatherOpcodes
    {
        WEATHER_FINE = 0x01,
        WEATHER_RAIN = 0x02,
        WEATHER_SNOW = 0x03
    }

    enum ZoneChangeOpcodes
    {
        ZoneChangeLoading = 1,
        ZoneChangeLoaded = 2,
        ZoneChangeTeleport = 3
    };

    internal enum MarketBBSOpcodes
    {
        MARKET_BBS_REGISTER = 0x01,
        MARKET_BBS_DELETE = 0x02,
        MARKET_BBS_REPORT = 0x03,
        MARKET_BBS_OPEN = 0x04,
        MARKET_BBS_REMOTE_PURCHASE = 0x05,
        MARKET_BBS_MESSAGE = 0x06,
    }

    enum PartyOpcodes
    {
        PARTY_CREATE = 0x01, // Party Group Create
        PARTY_PERMIT = 0x02, // Party Insert Permit
        PARTY_INSERT = 0x03, // Party Member Insert
        PARTY_REMOVE = 0x04, // Party Member Remove
        PARTY_DELETE = 0x05, // Party Group Delete
        PARTY_HPCHANGE = 0x06, // Party Member HP change
        PARTY_LEVELCHANGE = 0x07, // Party Member Level change
        PARTY_CLASSCHANGE = 0x08, // Party Member Class Change
        PARTY_STATUSCHANGE = 0x09, // Party Member Status ( disaster, poison ) Change
        PARTY_REGISTER = 0x0A, // Party Message Board Register
        PARTY_REPORT = 0x0B, // Party Request Message Board Messages
        PARTY_PROMOTE = 0x1C, // Promotes user to party leader
        PARTY_ALL_STATUSCHANGE = 0x1D // Sets the specified status of the selected party members to 1.

    }




}
