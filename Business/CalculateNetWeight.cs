namespace Business
{
    public class CalculateNetWeight
    {
        public double netWeight(double GrossWeight,double TareWeight)
        {
            return (GrossWeight - TareWeight) < 0 ? 0 : (GrossWeight - TareWeight);
        }
    }
}
