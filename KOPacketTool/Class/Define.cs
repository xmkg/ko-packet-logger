/**
 * ______________________________________________________
 * This file is part of ko-packet-logger project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */

// ReSharper disable All

namespace KOPacketTool
{
    enum KOOpcodes : byte
    {

        LS_CRYPTION = 0xF2,
        LS_LOGIN_REQ = 0xF3,
        LS_MGAME_LOGIN = 0xF4,
        LS_SERVERLIST = 0xF5,
        LS_NEWS = 0xF6,
        LS_UNKF7 = 0xF7,
        /*
            Gameserver login
        */
        WIZ_LOGIN = 0x01,
        /*
            New character creation (database)
        */
        WIZ_NEW_CHAR = 0x02,
        /*
            Existing character deletion (database)
        */
        WIZ_DEL_CHAR = 0x03,
        /*
            Character selection
        */
        WIZ_SEL_CHAR = 0x04,
        /*
            Nation selection
        */
        WIZ_SEL_NATION = 0x05,
        /*
            Character movement (speed, location)
        */
        WIZ_MOVE = 0x06,
        /*
            Region user join-leave information w/ character info
        */
        WIZ_USER_INOUT = 0x07,
        /*
            Normal attack (non-spell, default weapon attack)
        */
        WIZ_ATTACK = 0x08,
        /*
            Character rotation (degrees)
        */
        WIZ_ROTATE = 0x09,
        /*
            Region NPC join-leave information /w NPC info
        */
        WIZ_NPC_INOUT = 0x0A,
        /*
            Non-playing character movement (speed, location)
        */
        WIZ_NPC_MOVE = 0x0B,
        /*
            Account character information request for character selection screen
        */
        WIZ_ALLCHAR_INFO_REQ = 0x0C,
        /*
            Client gamestart (loading finalize), request regional NPC, merchant, user info and
            other details.
        */
        WIZ_GAMESTART = 0x0D,
        /*
            Complete character information with every single detail.
        */
        WIZ_MYINFO = 0x0E,
        /*
            Client logout information.
        */
        WIZ_LOGOUT = 0x0F,
        /*
            Chat system main operation code
        */
        WIZ_CHAT = 0x10,
        /*
            Character | NPC corpse information (so client can play the animation.)
        */
        WIZ_DEAD = 0x11,
        /*
            Character respawn related
        */
        WIZ_REGENE = 0x12,
        /*
            In-game time
        */
        WIZ_TIME = 0x13,
        /*
            In-game weather information (snow,rain,sunny)
        */
        WIZ_WEATHER = 0x14,
        /*
            Region join information about new user.
        */
        WIZ_REGIONCHANGE = 0x15,
        /*
            Client user information request about region user(s)
        */
        WIZ_REQ_USERIN = 0x16,
        /*
            Character HP change
        */
        WIZ_HP_CHANGE = 0x17,
        /*
            Character MSP change
        */
        WIZ_MSP_CHANGE = 0x18,
        /*
            Chatroom related stuff
        */
        WIZ_CHATROOM = 0x19,
        /*
            Character experience change
        */
        WIZ_EXP_CHANGE = 0x1A,
        /*
            Character level up or down.
            Includes Current / Max HP & MP, Weight and Experience information.
        */
        WIZ_LEVEL_CHANGE = 0x1B,
        /*
            Non-playing character region join broadcasting.
        */
        WIZ_NPC_REGION = 0x1C,  // Npc Region Change Receive
                                /*
                                    Client NPC info request about region NPC.
                                */
        WIZ_REQ_NPCIN = 0x1D,   // Client Request UnRegistered NPC List
                                /*
                                    User warp (instant coordinate change)
                                */
        WIZ_WARP = 0x1E,
        /*
            User item move.
            Includes;
            for client : old and new position information.
            for server : new stats, resistances, weight, HP and MP information.
        */
        WIZ_ITEM_MOVE = 0x1F,   // User Item Move
        WIZ_NPC_EVENT = 0x20,   // User Click Npc Event
                                /*
                                    Used by NPC vendors (armor, weapon etc. merchants)
                                */
        WIZ_ITEM_TRADE = 0x21,
        /*
            Selected target HP information & dealt damage.
        */
        WIZ_TARGET_HP = 0x22,
        /*
            Zone item bundle register.
        */
        WIZ_ITEM_DROP = 0x23,
        /*
            Item bundle content request
        */
        WIZ_BUNDLE_OPEN_REQ = 0x24,
        WIZ_TRADE_NPC = 0x25,   // ITEM Trade start
                                /*
                                    Item bundle loot request
                                */
        WIZ_ITEM_GET = 0x26,
        /*
            Character zone change
        */
        WIZ_ZONE_CHANGE = 0x27,
        /*
            Character stat change
        */
        WIZ_POINT_CHANGE = 0x28,
        /*
            Character state change 
            Includes : (standing,sitting), transformation, greetings etc.
        */
        WIZ_STATE_CHANGE = 0x29,
        /*
            Character national point, manner or leader point change.
        */
        WIZ_LOYALTY_CHANGE = 0x2A,
        /*
            Version information and public key exchanging
        */
        WIZ_VERSION_CHECK = 0x2B,
        /*
            Cryption public key sharing (only valid for loginserver)
        */
        WIZ_CRYPTION = 0x2C,
        /*
            Region character equipment change
        */
        WIZ_USERLOOK_CHANGE = 0x2D,
        /*
            Server notice information (content in Notice.txt)
        */
        WIZ_NOTICE = 0x2E,
        /*
            Party system operation code
        */
        WIZ_PARTY = 0x2F,
        /*
            Character item trade system
        */
        WIZ_EXCHANGE = 0x30,
        /*
            Magic system operation code
        */
        WIZ_MAGIC_PROCESS = 0x31,
        /*
            Character skill point change
        */
        WIZ_SKILLPT_CHANGE = 0x32,
        /*
            Character interaction with objects (eg. lever, gate, resurrection points.)
            Also includes magic anvil effects.
        */
        WIZ_OBJECT_EVENT = 0x33,
        /*
            Character class change (job unlock at 10 & 60)
        */
        WIZ_CLASS_CHANGE = 0x34,
        /*
            Character private chat current target selection
        */
        WIZ_CHAT_TARGET = 0x35,
        /*
            Current online user count
        */
        WIZ_CONCURRENTUSER = 0x36,
        /*
            Client character data save request
        */
        WIZ_DATASAVE = 0x37,
        /*
            Character item durability change
        */
        WIZ_DURATION = 0x38,
        /*
            Durational spell time notification
        */
        WIZ_TIMENOTIFY = 0x39,
        /*
            Item trade, upgrade and repair related
        */
        WIZ_REPAIR_NPC = 0x3A,
        /*
            Client item repair request
        */
        WIZ_ITEM_REPAIR = 0x3B,
        /*
            Knights system operation code
        */
        WIZ_KNIGHTS_PROCESS = 0x3C,
        /*
            Item count change (consume, loot or obtain)
        */
        WIZ_ITEM_COUNT_CHANGE = 0x3D,
        /*
            All knights ID information
        */
        WIZ_KNIGHTS_LIST = 0x3E,
        /*
            Client item destroy 
        */
        WIZ_ITEM_REMOVE = 0x3F,
        /*
            Gamemaster related stuff
        */
        WIZ_OPERATOR = 0x40,
        /*
            Speedhack control packet from client(includes TickCount information, pathetic stuff..)
        */
        WIZ_SPEEDHACK_CHECK = 0x41,
        /*
            Compressed packet (LZF)
        */
        WIZ_COMPRESS_PACKET = 0x42,
        /*
            Server Status Check Packet
        */
        WIZ_SERVER_CHECK = 0x43,
        /*
            Multiple packets inside a single packet
        */
        WIZ_CONTINOUS_PACKET = 0x44,
        /*
            Warehouse system operation code
        */
        WIZ_WAREHOUSE = 0x45,
        /*
            Gameserver change on-the-fly
        */
        WIZ_SERVER_CHANGE = 0x46,
        /*
            Bug report from client
        */
        WIZ_REPORT_BUG = 0x47,
        /*
            Client /town command
        */
        WIZ_HOME = 0x48,
        /*
            Friend system operation code
        */
        WIZ_FRIEND_PROCESS = 0x49,
        /*
            Character gold gain & lose
        */
        WIZ_GOLD_CHANGE = 0x4A,
        /*
            Warp gate zone list information
        */
        WIZ_WARP_LIST = 0x4B,
        /*
            Battle zone Server Info packet	(IP, Port)
        */
        WIZ_VIRTUAL_SERVER = 0x4C,
        /*
            Battle zone concurrent users request packet
        */
        WIZ_ZONE_CONCURRENT = 0x4D,
        /*
            To have your corpse have an ID on top of it.
        */
        WIZ_CORPSE = 0x4E,
        /*
            Party bulletin board service
        */
        WIZ_PARTY_BBS = 0x4F,
        /*
            Market bulletin board service
        */
        WIZ_MARKET_BBS = 0x50,
        /*
            Duplicate connection kickout (this account is already in use stuff)
        */
        WIZ_KICKOUT = 0x51,
        /*
            Client Event (for quest)
        */
        WIZ_CLIENT_EVENT = 0x52,
        /*
            War time counter, etc.
        */
        WIZ_WAR_SYSTEM = 0x53,
        /*
            Character weight change
        */
        WIZ_WEIGHT_CHANGE = 0x54,
        /*
            Non-playing character menu information
        */
        WIZ_SELECT_MSG = 0x55,
        WIZ_NPC_SAY = 0x56,// Select Event Message...
        WIZ_BATTLE_EVENT = 0x57,    // Battle Event Result
        WIZ_AUTHORITY_CHANGE = 0x58,// Authority change 
        WIZ_EDIT_BOX = 0x59,// Activate/Receive info from Input_Box.
        WIZ_SANTA = 0x5A,// Activate motherfucking Santa Claus!!! :(

        WIZ_ITEM_UPGRADE = 0x5B,
        WIZ_ZONEABILITY = 0x5E,
        WIZ_EVENT = 0x5F,
        WIZ_STEALTH = 0x60,// stealth related.
        WIZ_ROOM_PACKETPROCESS = 0x61, // room system
        WIZ_ROOM = 0x62,
        WIZ_QUEST = 0x64,
        WIZ_KISS = 0x66,
        WIZ_RECOMMEND_USER = 0x67,
        WIZ_MERCHANT = 0x68,
        WIZ_MERCHANT_INOUT = 0x69,
        WIZ_SHOPPING_MALL = 0x6A,
        WIZ_SERVER_INDEX = 0x6B,
        WIZ_EFFECT = 0x6C,
        WIZ_SIEGE = 0x6D,
        WIZ_NAME_CHANGE = 0x6E,
        WIZ_WEBPAGE = 0x6F,
        WIZ_CAPE = 0x70,
        WIZ_PREMIUM = 0x71,
        WIZ_HACKTOOL = 0x72,
        WIZ_RENTAL = 0x73,
        WIZ_CHALLENGE = 0x75,
        WIZ_PET = 0x76,
        WIZ_CHINA = 0x77,// we shouldn't need to worry about this
        WIZ_KING = 0x78,
        WIZ_SKILLDATA = 0x79,
        WIZ_PROGRAMCHECK = 0x7A,
        WIZ_BIFROST = 0x7B,
        WIZ_REPORT = 0x7C,
        WIZ_LOGOSSHOUT = 0x7D,
        WIZ_RANK = 0x80,
        WIZ_STORY = 0x81,
        WIZ_MINING = 0x86,
        WIZ_HELMET = 0x87,
        WIZ_PVP = 0x88,
        WIZ_CHANGE_HAIR = 0x89, // Changes hair colour/facial features at character selection
        WIZ_DEATH_LIST = 0x90,
        WIZ_CLANPOINTS_BATTLE = 0x91,// not sure


        WIZ_WATCHMAN = 0xCC, // Watchman related

        WIZ_TEST_PACKET = 0xff, // Test packet
    };
}
