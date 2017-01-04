﻿using ENet;

namespace LeagueSandbox.GameServer.Packets.PacketHandlers.Handlers
{
    class HandleView : IPacketHandler
    {
        private Game _game = Program.ResolveDependency<Game>();

        public bool HandlePacket(Peer peer, byte[] data)
        {
            var request = new ViewRequest(data);
            var answer = new ViewAnswer(request);
            if (request.requestNo == 0xFE)
            {
                answer.setRequestNo(0xFF);
            }
            else
            {
                answer.setRequestNo(request.requestNo);
            }
            _game.PacketHandlerManager.sendPacket(peer, answer, Channel.CHL_S2C, PacketFlags.None);
            return true;
        }
    }
}
