using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Linq;

namespace DogWalkies
{
    public class DogAdapter : BaseAdapter<Dog>
    {
        private DogAccessLayer data = DogAccessLayer.getInstance();
        private Activity context;

        public DogAdapter(Activity context)
        {
            this.context = context;
        }

        public override int Count
        {
            get
            {
                return data.getAllDogs().Count;
            }
        }

        public override Dog this[int position]
        {
            get
            {
                return data.getAllDogsOrdered().ElementAt<Dog>(position);
            }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            /*
            Dog doggo = this[position];

            if (convertView == null)
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SIMPLELISTITEM, null);

            TextView txt = convertView.FindViewById<TextView>(Android.Resource.Id.Text1);
            txt.Text = "" + st;//this will call the toString of the Student class
            return convertView;
            */

            throw new NotImplementedException();
        }
    }
}