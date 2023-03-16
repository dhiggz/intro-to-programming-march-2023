import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of, switchMap } from 'rxjs';
import { errorsEvents } from '../actions/errors.actions';
import {
  itemsCommands,
  itemsDocuments,
  itemsEvents,
} from '../actions/items.actions';
import { ItemEntity } from '../reducers/items.reducer';

@Injectable()
export class ItemsEffects {
  // add the new item
  // send that payload on the action to the API using a POST
  // when it comes the API, turn it into a itemsDocuments.item and send it to the reducers

  addItem$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemsEvents.itemCreationRequested),
      mergeMap(
        (
          a, // this is usually good for "non safe" operations (methods other than GET)
        ) =>
          this.client
            .post<ItemEntity>(
              'http://localhost:1340/learning-resources',
              a.payload,
            )
            .pipe(
              map((response) => itemsDocuments.item({ payload: response })),
              catchError(() =>
                of(
                  errorsEvents.errorHappened({
                    message: 'Welp, that failed! Sorry',
                  }),
                ),
              ),
            ),
      ),
    );
  });

  loadItems$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemsCommands.loadTheItems),
      switchMap(() =>
        // usually good for GET requests
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
