export interface Link {
  id: number;
  displayName: string;
  uri: string;
  probability: number;
  youTubeEmbedCode: string;
  youTubeStartTime: string;
}

export interface Config {
  name: string;
  links: Link[];
}
