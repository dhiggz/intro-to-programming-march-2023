import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, switchMap } from 'rxjs';
import { itemsCommands, itemsDocuments } from '../actions/items.actions';
import { ItemEntity } from '../reducers/items.reducer';

@Injectable()
export class ItemsEffects {
  // add the new item
  // send that payload on the action to the API using a POST
  // when it comes the API, turn it into a itemsDocuments.item and send it to the reducers

  loadItems$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemsCommands.loadTheItems),
      switchMap(() =>
        this.client
          .get<{ data: ItemEntity[] }>(
            'http://localhost:1340/learning-resources',
          )
          .pipe(
            map((response) => response.data),
            map((payload) => itemsDocuments.items({ payload })),
          ),
      ),
    );
  });
  constructor(private actions$: Actions, private client: HttpClient) {}
}
