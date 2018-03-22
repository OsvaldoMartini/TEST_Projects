namespace DrawStars.Abstracts
{
    public abstract class Star
    {
        private int _distance;
        private int _altitude;
        private int _latitude;

        // constructor
        public Star(int newDistance, int newAltitude, int newLatitude)
        {
            setDistance(newDistance);
            setAltitude(newAltitude);
            setLatitude(newLatitude);
        }

        // accessors for x & y coordinates
        public int getDistance() { return _distance; }
        public int getAltitude() { return _altitude; }

        public int getLatitude(){return _latitude;}

        public void setDistance(int newDistance) { _distance = newDistance; }
        public void setAltitude(int newAltitude) { _altitude = newAltitude; }
        public void setLatitude(int newLatitude) { _latitude = newLatitude; }

        // move the x & y coordinates
        public void moveTo(int newDistance, int newAltitude, int newLatitude)
        {
            setDistance(newDistance);
            setAltitude(newAltitude);
            setLatitude(newLatitude);
        }
        public void re_MoveTo(int alfaDistance, int alfaAltitude, int alfaLatitude)
        {
            moveTo(alfaDistance+ getDistance(), alfaAltitude + getAltitude(), alfaLatitude+ getLatitude());
        }


        // virtual routine - draw the shape
        public abstract void draw();
    }
}
