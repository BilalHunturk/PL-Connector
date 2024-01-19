namespace PSocket
{
    public class Packet
    {
        /// <summary>
        /// This is the time that packets will start to send AFTER x second.
        /// </summary>
        public int ATime = 0;
        /// <summary>
        /// This is the time that packets will  send EVERY x second
        /// </summary>
        public int Period { get; set; }
                
        public string Name { get; set; }

    }
}