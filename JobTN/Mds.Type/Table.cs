using System;
using System.Collections.Generic;
using System.Text;

namespace Mds.Type
{
  public class Table
  {

    public string Name { get; set; }

    public Field[] Fields { get; set; }

  }

  public class Field
  {
    public string Name { get; set; }

    public string DataType { get; set; }

  }
}
