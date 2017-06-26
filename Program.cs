using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LZTime.MMC;

namespace LZTime
{
				class Program
				{
								//Offsets
								public static int dwLocalPlayer = 0xAADFFC;
								public static int dwForceAttack = 0x2ECCA08;

								public static int m_iCrosshairId = 0xB2B4;

								//Client.dll offset
								public static int m_ClientPointer;


								static void Main(string[] args)
								{
												MMCManage.Initialize("csgo");
												//Finds Client.dll addres and saves it in the variable
												m_ClientPointer = MMCManage.GetModuleAdress("client.dll");


												while (true)
												{

																int address = m_ClientPointer + dwLocalPlayer;
																int localPlayer = MMCManage.ReadMemory<int>(address);

																address = localPlayer + m_iCrosshairId;
																int playerInCross = MMCManage.ReadMemory<int>(address);
																Console.WriteLine("Player" + playerInCross);
																if (playerInCross == 2)
																{
																				MMCManage.WriteMemory<IntPtr>(m_ClientPointer + dwForceAttack, 1);
																				Thread.Sleep(1);
																				MMCManage.WriteMemory<IntPtr>(m_ClientPointer + dwForceAttack, 4);

																}
												}
								}
				}
}
