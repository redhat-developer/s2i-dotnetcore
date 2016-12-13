package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;



import io.swagger.annotations.*;
import java.util.Objects;


public class User   {
  
  private Integer id = null;
  private String email = null;
  private String smUserId = null;
  private String givenName = null;

  /**
   * Primary Key
   **/
  public User id(Integer id) {
    this.id = id;
    return this;
  }

  
  @ApiModelProperty(example = "null", required = true, value = "Primary Key")
  @JsonProperty("Id")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  /**
   * Email address
   **/
  public User email(String email) {
    this.email = email;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "Email address")
  @JsonProperty("Email")
  public String getEmail() {
    return email;
  }
  public void setEmail(String email) {
    this.email = email;
  }

  /**
   * Security Manager User ID
   **/
  public User smUserId(String smUserId) {
    this.smUserId = smUserId;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "Security Manager User ID")
  @JsonProperty("SmUserId")
  public String getSmUserId() {
    return smUserId;
  }
  public void setSmUserId(String smUserId) {
    this.smUserId = smUserId;
  }

  /**
   * Last Name
   **/
  public User givenName(String givenName) {
    this.givenName = givenName;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "Last Name")
  @JsonProperty("GivenName")
  public String getGivenName() {
    return givenName;
  }
  public void setGivenName(String givenName) {
    this.givenName = givenName;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    User user = (User) o;
    return Objects.equals(id, user.id) &&
        Objects.equals(email, user.email) &&
        Objects.equals(smUserId, user.smUserId) &&
        Objects.equals(givenName, user.givenName);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, email, smUserId, givenName);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class User {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    email: ").append(toIndentedString(email)).append("\n");
    sb.append("    smUserId: ").append(toIndentedString(smUserId)).append("\n");
    sb.append("    givenName: ").append(toIndentedString(givenName)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
}

