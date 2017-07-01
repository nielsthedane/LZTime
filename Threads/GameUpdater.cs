using System.Threading;
using LZTime.Struct;
using LZTime.Var;
using static LZTime.Struct.Entitys;
using static LZTime.Struct.Entitys.Entity;

namespace LZTime.Threads

{
				public class GameUpdater
				{
					private MMC.MMCManage Memory;
								public void Read()
								{
												Memory = MMC.MMCManage.Instance;
												while (true)
												{
																//LOCAL
																Entitys.LocalPlayer.m_iBase = Memory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.m_dwLocalPlayer);
																Entitys.LocalPlayer.m_iTeam = Memory.ReadMemory<int>(Entitys.LocalPlayer.m_iBase + Offsets.m_iTeamNum);
																//Entitys.LocalPlayer.m_iClientState = MMCManage.ReadMemory<int>(Offsets.m_EnginePointer + Offsets.m_dwClientState);

																for (var i = 0; i < 64; i++)
																{
																				Entity Entity = Arrays.Entity[i];

																				Entity.m_iBase = Memory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.m_dwEntityList + i * 0x10);

																				if (Entity.m_iBase > 0)
																				{
																								Entity.m_iTeam = Memory.ReadMemory<int>(Entity.m_iBase + Offsets.m_iTeamNum);
																								Entity.m_iHealth = Memory.ReadMemory<int>(Entity.m_iBase + Offsets.m_iHealth);
																				}
																}
															Thread.Sleep(1);
												}
								}
				}
}
