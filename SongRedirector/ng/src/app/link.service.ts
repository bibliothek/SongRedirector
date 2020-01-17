import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: "root"
})
export class LinkService {

  private endpoint = "/api/config";

  constructor(private httpClient: HttpClient) {}

  getRandomLink(): Observable<Link> {
    return this.httpClient.get<Link>(`${this.endpoint}/default/link`);
  }
}

export interface Link {
  id: number;
  displayName: string;
  uri: string;
  probability: number;
  youTubeEmbedCode: string;
  youTubeStartTime: string;
}
