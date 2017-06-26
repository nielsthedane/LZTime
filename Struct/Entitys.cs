namespace LZTime.Struct
{
				public class Entitys
				{
								public struct Entity
								{
												public int m_iBase;
												public int m_iHealth;
												public int m_iTeam;

												internal class Arrays
												{
																public static Entity[] Entity = new Entity[64];
												}

								}

								public struct LocalPlayer
								{
												public static int m_iBase;
												public static int m_iTeam;
												public static int m_iClientState;
								}
				}
}