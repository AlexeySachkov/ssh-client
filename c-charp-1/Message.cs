using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_charp_1
{
    class Message
    {
         //        Message ID                            Value         Reference
         //        -----------                           -----         ---------
         const int SSH_MSG_DISCONNECT                   =   1;  //     [SSH-TRANS]
         const int SSH_MSG_IGNORE                       =   2;  //     [SSH-TRANS]
         const int SSH_MSG_UNIMPLEMENTED                =   3;  //     [SSH-TRANS]
         const int SSH_MSG_DEBUG                        =   4;  //     [SSH-TRANS]
         const int SSH_MSG_SERVICE_REQUEST              =   5;  //     [SSH-TRANS]
         const int SSH_MSG_SERVICE_ACCEPT               =   6;  //     [SSH-TRANS]
         const int SSH_MSG_KEXINIT                      =  20;  //     [SSH-TRANS]
         const int SSH_MSG_NEWKEYS                      =  21;  //     [SSH-TRANS]
         const int SSH_MSG_USERAUTH_REQUEST             =  50;  //     [SSH-USERAUTH]
         const int SSH_MSG_USERAUTH_FAILURE             =  51;  //     [SSH-USERAUTH]
         const int SSH_MSG_USERAUTH_SUCCESS             =  52;  //     [SSH-USERAUTH]
         const int SSH_MSG_USERAUTH_BANNER              =  53;  //     [SSH-USERAUTH]
         const int SSH_MSG_GLOBAL_REQUEST               =  80;  //     [SSH-CONNECT]
         const int SSH_MSG_REQUEST_SUCCESS              =  81;  //     [SSH-CONNECT]
         const int SSH_MSG_REQUEST_FAILURE              =  82;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_OPEN                 =  90;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_OPEN_CONFIRMATION    =  91;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_OPEN_FAILURE         =  92;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_WINDOW_ADJUST        =  93;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_DATA                 =  94;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_EXTENDED_DATA        =  95;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_EOF                  =  96;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_CLOSE                =  97;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_REQUEST              =  98;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_SUCCESS              =  99;  //     [SSH-CONNECT]
         const int SSH_MSG_CHANNEL_FAILURE              = 100;  //     [SSH-CONNECT]


    }
}
