import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { State, process } from '@progress/kendo-data-query';
import { map } from 'rxjs/operators/map';
import { isError } from 'util';



import { CreateCatalogService, Field, Table } from './create-catalog.service';
import { error } from 'protractor';


@Component({
  selector: 'app-create-catalog',
  templateUrl: './create-catalog.component.html',
  providers: [CreateCatalogService]
})

export class CreateCatalogComponent {
  public isVersionCatalog: boolean = false;
  public dataTypes: string[] = ["INTEGER", "DOUBLE", "NTEXT", "DATE", "BIT"];
  public selectedDataType: string = undefined;
  public selectedFieldName: string;
  public table: Table = new Table();

  constructor(private service: CreateCatalogService) {
  }

  public addField() {
    let isExistField = this.table.fields.some(item => {
      return item.name == this.selectedFieldName
    });

    let hasDataType = this.selectedDataType == undefined;
    if (!hasDataType) {
      if (!isExistField) {
        let field = new Field();
        field.name = this.selectedFieldName;
        field.dataType = this.selectedDataType;
        this.table.fields.push(field);
      } else {
        alert("Столбец с таким именем существует!");
      }
    } else {
      alert("Выберите тип данных!");
    }
  }

  public onCreateTable() {
    if (this.table.fields.length == 0 || this.table.name == undefined) {
      alert("Заполните данные!");
    } else {
      this.service.postCreateTable(this.table).subscribe(
        result => alert(result),
        error => { console.error(error); }
      );
      this.reset();
      alert("Ok");
    }
  }

  public removeHandler({ sender, dataItem }) {
    this.table.fields.splice(this.table.fields.findIndex(e => e.name === dataItem.name), 1);
    sender.cancelCell();
  }

  private reset() {
    this.table.fields = [];
    this.table.name = undefined;
  }
}





