import { Component } from '@angular/core';
import { GridDataResult, PageChangeEvent, RowArgs, SelectableSettings } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
})
export class CatalogComponent {
  public selectableSettings: SelectableSettings = {
    checkboxOnly: true,
    mode: 'single'
  };
  public selectedCatalog: boolean = false;
  public catalogs: any[] = [
    {
      name: "catalog1",
      workedVersion: "1.0.1"
    },
    {
      name: "catalog2",
      workedVersion: "2.0.1"
    },
    {
      name: "catalog3",
      workedVersion: "3.0.1"
    }
  ];

  public columns: any[] = [{ column: "Id" }, { column: "Name" }, { column: "Value" }];

  public selectionCatalog(e): void {
    if (e.selectedRows.length >= 0) {
      let item = e.selectedRows[0].dataItem;
    }
  }


}

export class Catalog {
  name: string;
  workedVersion: string;
}
